<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.FullDay_btn = New System.Windows.Forms.Button()
        Me.btn_View = New System.Windows.Forms.Button()
        Me.CBX_employee_id = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_end = New System.Windows.Forms.Button()
        Me.btn_start = New System.Windows.Forms.Button()
        Me.DTP_set_date = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btn_show_data = New System.Windows.Forms.Button()
        Me.ToDate = New System.Windows.Forms.DateTimePicker()
        Me.FromDate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn_export_data = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.FullDay_btn)
        Me.GroupBox1.Controls.Add(Me.btn_View)
        Me.GroupBox1.Controls.Add(Me.CBX_employee_id)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btn_end)
        Me.GroupBox1.Controls.Add(Me.btn_start)
        Me.GroupBox1.Controls.Add(Me.DTP_set_date)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(1352, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(293, 120)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Daily Work"
        '
        'FullDay_btn
        '
        Me.FullDay_btn.Location = New System.Drawing.Point(229, 86)
        Me.FullDay_btn.Name = "FullDay_btn"
        Me.FullDay_btn.Size = New System.Drawing.Size(56, 23)
        Me.FullDay_btn.TabIndex = 6
        Me.FullDay_btn.Text = "Full Day"
        Me.FullDay_btn.UseVisualStyleBackColor = True
        '
        'btn_View
        '
        Me.btn_View.Location = New System.Drawing.Point(85, 86)
        Me.btn_View.Name = "btn_View"
        Me.btn_View.Size = New System.Drawing.Size(56, 23)
        Me.btn_View.TabIndex = 4
        Me.btn_View.Text = "View"
        Me.btn_View.UseVisualStyleBackColor = True
        '
        'CBX_employee_id
        '
        Me.CBX_employee_id.FormattingEnabled = True
        Me.CBX_employee_id.Items.AddRange(New Object() {"עבד", "עלא"})
        Me.CBX_employee_id.Location = New System.Drawing.Point(85, 21)
        Me.CBX_employee_id.Name = "CBX_employee_id"
        Me.CBX_employee_id.Size = New System.Drawing.Size(200, 21)
        Me.CBX_employee_id.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Employee ID "
        '
        'btn_end
        '
        Me.btn_end.Location = New System.Drawing.Point(154, 86)
        Me.btn_end.Name = "btn_end"
        Me.btn_end.Size = New System.Drawing.Size(59, 23)
        Me.btn_end.TabIndex = 3
        Me.btn_end.Text = "End Day"
        Me.btn_end.UseVisualStyleBackColor = True
        '
        'btn_start
        '
        Me.btn_start.Location = New System.Drawing.Point(10, 86)
        Me.btn_start.Name = "btn_start"
        Me.btn_start.Size = New System.Drawing.Size(59, 23)
        Me.btn_start.TabIndex = 2
        Me.btn_start.Text = "Start Day"
        Me.btn_start.UseVisualStyleBackColor = True
        '
        'DTP_set_date
        '
        Me.DTP_set_date.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_set_date.Location = New System.Drawing.Point(85, 47)
        Me.DTP_set_date.Name = "DTP_set_date"
        Me.DTP_set_date.Size = New System.Drawing.Size(200, 20)
        Me.DTP_set_date.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Current Date"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1334, 893)
        Me.DataGridView1.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_show_data)
        Me.GroupBox2.Controls.Add(Me.ToDate)
        Me.GroupBox2.Controls.Add(Me.FromDate)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.btn_export_data)
        Me.GroupBox2.Location = New System.Drawing.Point(1352, 138)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(293, 758)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Hours Report"
        '
        'btn_show_data
        '
        Me.btn_show_data.Location = New System.Drawing.Point(10, 729)
        Me.btn_show_data.Name = "btn_show_data"
        Me.btn_show_data.Size = New System.Drawing.Size(91, 23)
        Me.btn_show_data.TabIndex = 8
        Me.btn_show_data.Text = "Show Data"
        Me.btn_show_data.UseVisualStyleBackColor = True
        '
        'ToDate
        '
        Me.ToDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.ToDate.Location = New System.Drawing.Point(52, 54)
        Me.ToDate.Name = "ToDate"
        Me.ToDate.Size = New System.Drawing.Size(233, 20)
        Me.ToDate.TabIndex = 7
        '
        'FromDate
        '
        Me.FromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.FromDate.Location = New System.Drawing.Point(52, 28)
        Me.FromDate.Name = "FromDate"
        Me.FromDate.Size = New System.Drawing.Size(233, 20)
        Me.FromDate.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "To  :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "From  :"
        '
        'btn_export_data
        '
        Me.btn_export_data.Location = New System.Drawing.Point(194, 729)
        Me.btn_export_data.Name = "btn_export_data"
        Me.btn_export_data.Size = New System.Drawing.Size(91, 23)
        Me.btn_export_data.TabIndex = 0
        Me.btn_export_data.Text = "Export To Excl"
        Me.btn_export_data.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1657, 908)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.ShowIcon = False
        Me.Text = "Optimum Hours System"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CBX_employee_id As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_end As System.Windows.Forms.Button
    Friend WithEvents btn_start As System.Windows.Forms.Button
    Friend WithEvents DTP_set_date As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_export_data As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents FromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_View As System.Windows.Forms.Button
    Friend WithEvents btn_show_data As System.Windows.Forms.Button
    Friend WithEvents FullDay_btn As System.Windows.Forms.Button

End Class
