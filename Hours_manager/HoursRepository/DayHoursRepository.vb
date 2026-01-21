Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop

Public Class DayHoursRepository
    Public connectionString As String = ""
    Private _CurrentEmployeeID As Integer
    Private _CurrentEmployeeName As String
    Public Sub New(ByVal id As Integer, ByVal name As String)
        _CurrentEmployeeID = id
        _CurrentEmployeeName = name
    End Sub
    Public Sub ChengTheUser(ByVal id As Integer, ByVal name As String)
        _CurrentEmployeeID = id
        _CurrentEmployeeName = name
    End Sub
    Private Function GetSqlConnection() As SqlConnection
        Dim connection As New SqlConnection(connectionString)
        connection.Open()
        Return connection
    End Function


    Function GetHoursBetweenDates(ByVal startDate As Date, ByVal endDate As Date) As List(Of DayHours)
        ' Method to retrieve data between two dates
        Dim workDays As New List(Of DayHours)()

        Try


            Using connection As SqlConnection = GetSqlConnection()

                Dim start_temp = Format(startDate, "yyyy-MM-dd")
                Dim end_temp = Format(endDate.AddDays(+1), "yyyy-MM-dd")

                ' Execute SQL operations
                Dim query As String = "SELECT * FROM WorkHours WHERE ID=" & _CurrentEmployeeID & " AND Check_In BETWEEN '" & start_temp & "' AND '" & end_temp & "'"

                Using command As New SqlCommand(query, connection)
                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim workDay As New DayHours()
                            workDay.RowNumber = reader("RowNumber")
                            workDay.ID = reader("ID")
                            workDay.Name = reader("Name").ToString()
                            workDay.Check_In = Convert.ToDateTime(reader("Check_In"))
                            workDay.Check_Out = If(IsDBNull(reader("Check_Out")), Nothing, Convert.ToDateTime(reader("Check_Out")))
                            workDay.TotalWorkHours = If(IsDBNull(reader("TotalWorkHours")), 0, Convert.ToDouble(reader("TotalWorkHours")))
                            workDays.Add(workDay)
                        End While
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
            Return Nothing
        End Try
        Return workDays
    End Function



    Sub GetAllHoursByEmploye()

    End Sub

    Sub Check_In()
        Try
            Using connection As SqlConnection = GetSqlConnection()

                Dim query As String = "INSERT INTO WorkHours (ID, Name, Check_In) VALUES (@ID, @Name, @Check_In)"

                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@ID", _CurrentEmployeeID)
                    command.Parameters.AddWithValue("@Name", _CurrentEmployeeName)
                    command.Parameters.AddWithValue("@Check_In", DateTime.Parse(Format(Now, "yyyy-MM-dd HH:mm:ss")))
                    command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred during check-in: " & ex.Message)
        End Try
    End Sub

    ' Helper Method to Get HourIn
    Public Function GetEmployeeHourIn() As TimeSpan
        Using connection As SqlConnection = GetSqlConnection()

            Dim query As String = "SELECT TOP 1 Check_In FROM WorkHours WHERE ID = @ID AND DateOut IS NULL ORDER BY RowNumber DESC"

            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@ID", _CurrentEmployeeID)

                Using reader As SqlDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        Return TimeSpan.Parse(reader("Check_In").ToString())
                    End If
                End Using
            End Using
        End Using

        Return TimeSpan.Zero
    End Function

    ' Helper Method to Get HourIn
    Public Function GetHourIn() As Boolean
        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Dim query As String = "SELECT TOP 1 HourIn FROM WorkDays WHERE ID = @ID AND DateOut IS NULL ORDER BY RowNumber DESC"

            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@ID", _CurrentEmployeeID)

                Using reader As SqlDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        Return True
                    End If
                End Using
            End Using
        End Using

        Return False
    End Function

    Sub Check_Out()
        ' Check-Out Method
        Try
            Using connection As SqlConnection = GetSqlConnection()

                Dim query As String = "UPDATE WorkHours SET Check_Out = @Check_Out, TotalWorkHours = @TotalWorkHours WHERE ID = @ID AND Check_Out IS NULL"

                Using command As New SqlCommand(query, connection)

                    Dim hourOut As TimeSpan = DateTime.Now.TimeOfDay
                    Dim hourIn As TimeSpan = GetEmployeeHourIn()

                    Dim totalWorkHours As Double = (hourOut - hourIn).TotalHours

                    command.Parameters.AddWithValue("@Check_Out", DateTime.Parse(Format(Now, "yyyy-MM-dd HH:mm:ss")))
                    command.Parameters.AddWithValue("@TotalWorkHours", totalWorkHours)
                    command.Parameters.AddWithValue("@ID", _CurrentEmployeeID)

                    Dim rowsAffected As Integer = command.ExecuteNonQuery()
                    If rowsAffected = 0 Then
                        MessageBox.Show("No matching record found to update.")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred during check-out: " & ex.Message)
        End Try

    End Sub

    Sub InsartFullDay(ByVal currentday As DateTime)
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Dim query As String = "INSERT INTO WorkHours (ID, Name, Check_In,Check_Out,TotalWorkHours) VALUES (@ID, @Name, @Check_In,@Check_Out,@TotalWorkHours)"

                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@ID", _CurrentEmployeeID)
                    command.Parameters.AddWithValue("@Name", _CurrentEmployeeName)
                    command.Parameters.AddWithValue("@Check_In", DateTime.Parse(Format(currentday, "yyyy-MM-dd") & " 08:30:00"))
                    command.Parameters.AddWithValue("@Check_Out", DateTime.Parse(Format(currentday, "yyyy-MM-dd") & " 18:00:00"))
                    command.Parameters.AddWithValue("@TotalWorkHours", calculate())
                    command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred during check-in: " & ex.Message)
        End Try
    End Sub

    Private Function calculate() As Double
        Dim hourOut As TimeSpan = TimeSpan.Parse("18:00")
        Dim hourIn As TimeSpan = TimeSpan.Parse("08:30")

        Dim totalWorkHours As Double = (hourOut - hourIn).TotalHours

        Return totalWorkHours
    End Function

    Sub DeleteWorkDay(ByVal rownumber)
        Try
            Using connection As SqlConnection = GetSqlConnection()
                Dim sql As String = "Delete  From WorkHours WHERE ID = " & _CurrentEmployeeID & " AND RowNumber = " & rownumber
                Using command As New SqlCommand(sql, connection)

                    Dim rowsAffected As Integer = command.ExecuteNonQuery()
                    If rowsAffected = 0 Then
                        MessageBox.Show("No matching record found to update.")
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("An error occurred during check-out: " & ex.Message)
        End Try
    End Sub

    Sub EditAnyField(ByVal updatedData As DayHours)
        ' Check-Out Method
        Try
            Using connection As SqlConnection = GetSqlConnection()

                Dim query As String = "UPDATE WorkHours SET Check_In = @Check_In ,Check_Out = @Check_Out, TotalWorkHours = @TotalWorkHours WHERE ID = @ID AND RowNumber = @RowNumber"

                Using command As New SqlCommand(query, connection)
                    Dim checkin = Format(updatedData.Check_In, "yyyy-MM-dd HH:mm:ss")
                    Dim checkout = Format(updatedData.Check_Out, "yyyy-MM-dd HH:mm:ss")
                    Dim hourOut As TimeSpan = TimeSpan.Parse(Format(updatedData.Check_Out, "HH:mm:ss"))
                    Dim hourIn As TimeSpan = TimeSpan.Parse(Format(updatedData.Check_In, "HH:mm:ss"))
                    Dim totalWorkHours As Double = (hourOut - hourIn).TotalHours
                    command.Parameters.AddWithValue("@Check_In", checkin)
                    command.Parameters.AddWithValue("@Check_Out", checkout)
                    command.Parameters.AddWithValue("@TotalWorkHours", totalWorkHours)
                    command.Parameters.AddWithValue("@ID", _CurrentEmployeeID)
                    command.Parameters.AddWithValue("@RowNumber", updatedData.RowNumber)

                    Dim rowsAffected As Integer = command.ExecuteNonQuery()
                    If rowsAffected = 0 Then
                        MessageBox.Show("No matching record found to update.")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred during check-out: " & ex.Message)
        End Try

    End Sub

    Public Sub ExportDataToExcel(ByVal startDate As Date, ByVal endDate As Date, ByVal filePath As String)
        Dim excelApp As Excel.Application = Nothing
        Dim workbook As Excel.Workbook = Nothing
        Dim worksheet As Excel.Worksheet = Nothing

        Try
            ' Retrieve data from database
            Dim workDays As List(Of DayHours) = GetHoursBetweenDates(startDate, endDate)

            If workDays.Count <= 0 Then
                MessageBox.Show("No Data To Export Try Again...")
                Return
            End If

            ' Create a new Excel application instance
            excelApp = New Excel.Application()
            workbook = excelApp.Workbooks.Add()
            worksheet = workbook.Sheets(1)
            worksheet.Name = "HoursSheet"

            ' Add header row
            worksheet.Cells(1, 1).Value = "מספר שורה"
            worksheet.Cells(1, 2).Value = "תאריך כניסה"
            worksheet.Cells(1, 3).Value = "שעת כניסה"
            worksheet.Cells(1, 4).Value = "תאריך יציאה"
            worksheet.Cells(1, 5).Value = "שעת יציאה"
            worksheet.Cells(1, 6).Value = "ס""כ שעות עבודה ליום"


            ' Add data rows
            Dim row As Integer = 2
            Dim lines As Integer = 0
            Dim ExclTotal As Double
            For Each workDay As DayHours In workDays
                lines = lines + 1
                worksheet.Cells(row, 1).Value = lines
                worksheet.Cells(row, 2).Value = Format(workDay.Check_In, "dd/MM/yyyy")
                worksheet.Cells(row, 3).Value = Format(workDay.Check_In, "HH:mm")
                worksheet.Cells(row, 4).Value = Format(workDay.Check_Out, "dd/MM/yyyy")
                worksheet.Cells(row, 5).Value = Format(workDay.Check_Out, "HH:mm")
                worksheet.Cells(row, 6).Value = workDay.TotalWorkHours

                ExclTotal = ExclTotal + workDay.TotalWorkHours
                row += 1
            Next
            row += 5
            worksheet.Cells(row, 5).Value = "ס""כ שעות עבודה כללי"
            worksheet.Cells(row, 6).Value = ExclTotal
            row += 1
            worksheet.Cells(row, 5).Value = "ס""כ ימי עבודה"
            worksheet.Cells(row, 6).Value = lines

            ' Save the workbook
            workbook.SaveAs(filePath)
            workbook.Close()
            excelApp.Quit()

            Console.WriteLine("Data exported successfully to " & filePath)
        Catch ex As Exception
            Console.WriteLine("An error occurred: " & ex.Message)
        Finally
            ' Clean up
            If worksheet IsNot Nothing Then Marshal.ReleaseComObject(worksheet)
            If workbook IsNot Nothing Then Marshal.ReleaseComObject(workbook)
            If excelApp IsNot Nothing Then Marshal.ReleaseComObject(excelApp)
            worksheet = Nothing
            workbook = Nothing
            excelApp = Nothing
            GC.Collect()
        End Try
    End Sub


End Class
