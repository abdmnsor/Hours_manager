Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices

Public Class Form1
    Public CurrentEmployeeID As Integer
    Public CurrentEmployeeName As String
    Public bindingSource As New BindingSource()
    Public _HourRepository As DayHoursRepository
    Public CurrentEmplyeHours As New List(Of DayHours)

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CurrentEmployeeID = 1
        CurrentEmployeeName = "עבד"
        _HourRepository = New DayHoursRepository(CurrentEmployeeID, CurrentEmployeeName)
        CBX_employee_id.SelectedIndex = 0

        Dim totaldays = DateTime.DaysInMonth(Now.Year, Now.Month)
        Dim DateTimeCustom As String = "01/" & Now.Month & "/" & Now.Year
        Dim setfirstdate = DateTime.Parse(DateTimeCustom)

        FromDate.Value = DateTimeCustom
        ToDate.Value = setfirstdate.AddDays(totaldays - 1)
        ReLoadData()


    End Sub



    Private Sub btn_start_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_start.Click
        If CBX_employee_id.SelectedItem <> "" Then
            If Not _HourRepository.GetHourIn() Then
                _HourRepository.Check_In()
                ReLoadData()
            Else
                MessageBox.Show("Allready Checked In...")
            End If
        Else
            MessageBox.Show("Most Select Employee First...")
        End If
    End Sub

    Private Sub btn_end_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_end.Click
        If CBX_employee_id.SelectedItem <> "" Then
            If _HourRepository.GetHourIn() Then
                _HourRepository.Check_Out()
                ReLoadData()
            Else
                MessageBox.Show("Allready Checked Out...")
            End If
        Else
            MessageBox.Show("Most Select Employee First...")

        End If
    End Sub


    Sub ReLoadData()

        CurrentEmplyeHours = _HourRepository.GetHoursBetweenDates(FromDate.Text, ToDate.Text)

        DataGridViewManegeData()
    End Sub


    Private Sub CBX_employee_id_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBX_employee_id.SelectedIndexChanged

        Select Case CBX_employee_id.SelectedItem
            Case "עלא"
                CurrentEmployeeID = 2
                CurrentEmployeeName = "עלא"
            Case "עבד"
                CurrentEmployeeID = 1
                CurrentEmployeeName = "עבד"
            Case Else
                MessageBox.Show("Employee Is Not Exist Please Try Again ...")
        End Select
        _HourRepository.ChengTheUser(CurrentEmployeeID, CurrentEmployeeName)
        ReLoadData()
        DataGridViewManegeData(CurrentEmployeeID)
    End Sub

    '    DataGridView1.DataSource = bindingSource
    '    DataGridView1.Columns(0).HeaderText = "מספר מזהה"
    'End Sub
    Sub DataGridViewManegeData(Optional ByVal CurrentEmployeeID As Integer = 1)
        Try
            ' Set the data source for the DataGridView
            DataGridView1.DataSource = Nothing ' Clear previous data source
            Dim data As List(Of DayHours) = CurrentEmplyeHours
            DataGridView1.DataSource = data
            DataGridView1.AutoGenerateColumns = False ' Disable auto-generation of columns
            DataGridView1.AutoResizeColumns()

            ' Check if the button column already exists to prevent duplicates
            If DataGridView1.Columns("MyButtonColumn") Is Nothing Then
                ' Create and add the button column
                Dim buttonColumn As New DataGridViewButtonColumn()
                buttonColumn.Name = "MyButtonColumn"
                buttonColumn.HeaderText = "Actions"
                buttonColumn.Text = "Delete"
                buttonColumn.UseColumnTextForButtonValue = True
                DataGridView1.Columns.Add(buttonColumn)
            End If


            DataGridView1.Columns(0).HeaderText = "מספר שורה"
            DataGridView1.Columns(0).Width = 110

            DataGridView1.Columns(1).HeaderText = "מספר עובד"
            DataGridView1.Columns(1).Width = 80
            DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DataGridView1.Columns(2).HeaderText = "שם עובד"
            DataGridView1.Columns(2).Width = 200
            DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DataGridView1.Columns(3).HeaderText = "תחילת משמרת"
            DataGridView1.Columns(3).Width = 300
            DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DataGridView1.Columns(4).HeaderText = "סיום משמרת"
            DataGridView1.Columns(4).Width = 300
            DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DataGridView1.Columns(5).HeaderText = "ס""כ שעות עבודה"
            DataGridView1.Columns(5).Width = 200
            DataGridView1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DataGridView1.Columns(6).HeaderText = "פעולה"
            DataGridView1.Columns(6).Width = 100
            ' Check that the number of columns is sufficient before applying formatting
            'If DataGridView1.Columns.Count > 7 Then
            '    DataGridView1.Columns(3).DefaultCellStyle.Format = "d" ' Date format
            '    DataGridView1.Columns(4).DefaultCellStyle.Format = "t" ' Time format
            '    DataGridView1.Columns(6).DefaultCellStyle.Format = "t" ' Time format
            '    DataGridView1.Columns(5).DefaultCellStyle.Format = "n" ' Number format
            'Else
            '    MessageBox.Show("The data source does not have enough columns.")
            'End If

        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
    End Sub

    ' Method to add a new row to the DataGridView
    Sub AddNewRow()
        Try
            ' Ensure the data source is set before adding a new row
            Dim dt As DataTable = CType(DataGridView1.DataSource, DataTable)

            ' Check if the data source is not null
            If dt IsNot Nothing Then
                ' Create a new row in the DataTable and populate it
                Dim newRow As DataRow = dt.NewRow()
                newRow(0) = "New Data"   ' Example for column 0
                newRow(1) = "New Data"   ' Example for column 1
                ' Add data for all columns...

                ' Add the new row to the DataTable
                dt.Rows.Add(newRow)
            Else
                MessageBox.Show("No data source is available.")
            End If

        Catch ex As Exception
            MessageBox.Show("An error occurred while adding a row: " & ex.Message)
        End Try
    End Sub

    '' Method to get all work hours for a specific employee ID
    'Public Function GetAllHours(ByVal employeeId As Integer) As List(Of WorkDay)
    '    Dim workDays As New List(Of WorkDay)()

    '    Try
    '        Using connection As New SqlConnection(connectionString)
    '            connection.Open()

    '            Dim query As String = "SELECT * FROM WorkDays WHERE ID = @ID"

    '            Using command As New SqlCommand(query, connection)
    '                command.Parameters.AddWithValue("@ID", employeeId)

    '                Using reader As SqlDataReader = command.ExecuteReader()
    '                    While reader.Read()
    '                        Dim workDay As New WorkDay()
    '                        workDay.RowNumber = reader("RowNumber")
    '                        workDay.ID = reader("ID")
    '                        workDay.Name = reader("Name").ToString()
    '                        workDay.DateIn = Convert.ToDateTime(reader("DateIn"))
    '                        workDay.HourIn = Convert.ToDateTime(reader("HourIn").ToString())
    '                        workDay.DateOut = If(IsDBNull(reader("DateOut")), vbNull, Convert.ToDateTime(reader("DateOut")))
    '                        workDay.HourOut = reader("HourOut")
    '                        workDay.TotalWorkHours = If(IsDBNull(reader("TotalWorkHours")), 0, Convert.ToDouble(reader("TotalWorkHours")))
    '                        workDay.ExportData = Convert.ToInt32(reader("ExportData"))
    '                        workDays.Add(workDay)
    '                    End While
    '                End Using
    '            End Using
    '        End Using
    '    Catch ex As Exception
    '        MessageBox.Show("An error occurred: " & ex.Message)
    '    End Try

    '    Return workDays
    'End Function

    ' Method to export data to Excel between two dates
    

   

    Private Sub btn_export_data_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_export_data.Click
        _HourRepository.ExportDataToExcel(FromDate.Text, ToDate.Text, Application.StartupPath & "\Hours_" & CurrentEmployeeName & ".xls")

    End Sub

    Private Sub btn_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_View.Click
        ReLoadData()
    End Sub


    Private Sub btn_show_data_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_show_data.Click
        _HourRepository.GetHoursBetweenDates(FromDate.Text, ToDate.Text)
        ReLoadData()
    End Sub

    Private Sub DataGridView1_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        If e.RowIndex >= 0 Then


            Dim UpdatedData As New DayHours With {
                .RowNumber = DataGridView1.Rows(e.RowIndex).Cells.Item(0).Value,
                .ID = DataGridView1.Rows(e.RowIndex).Cells.Item(1).Value,
                .Name = DataGridView1.Rows(e.RowIndex).Cells.Item(2).Value,
                .Check_In = DataGridView1.Rows(e.RowIndex).Cells.Item(3).Value,
                .Check_Out = DataGridView1.Rows(e.RowIndex).Cells.Item(4).Value,
                .TotalWorkHours = DataGridView1.Rows(e.RowIndex).Cells.Item(0).Value
                }
            _HourRepository.EditAnyField(UpdatedData)
            ReLoadData()
        End If
    End Sub

    Private Sub FullDay_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FullDay_btn.Click
        _HourRepository.InsartFullDay(DTP_set_date.Text)
        ReLoadData()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        ' Ensure that the column is the button column
        If e.ColumnIndex = DataGridView1.Columns("MyButtonColumn").Index Then
            Dim rownumber As String = DataGridView1.Rows(e.RowIndex).Cells.Item(0).Value

            _HourRepository.DeleteWorkDay(rownumber)
            ReLoadData()
            ' You can access the row and column index using e.RowIndex and e.ColumnIndex
            ' חיבור ה-BindingSource ל-DataGridView
            'Dim bindingSource As New BindingSource()
            'bindingSource.DataSource = GetAllHours(CurrentEmployeeID)

            'DataGridView1.DataSource = BindingSource

            '' מחיקת שורה (שורה מספר 0 למשל)
            'BindingSource.RemoveAt(0)
            MessageBox.Show("Row Deleted Success...!")
        End If
    End Sub

End Class



