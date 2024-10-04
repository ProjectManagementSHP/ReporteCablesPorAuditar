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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.PanelContros = New System.Windows.Forms.Panel()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.cmbAU = New System.Windows.Forms.ComboBox()
        Me.cmbRev = New System.Windows.Forms.ComboBox()
        Me.lblTWIP = New System.Windows.Forms.Label()
        Me.cmbWIP = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTAU = New System.Windows.Forms.Label()
        Me.PanelGrid = New System.Windows.Forms.Panel()
        Me.lblTOperaciones = New System.Windows.Forms.Label()
        Me.GridOperaciones = New System.Windows.Forms.DataGridView()
        Me.lblRecordsGridOperaciones = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.PanelContros.SuspendLayout()
        Me.PanelGrid.SuspendLayout()
        CType(Me.GridOperaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.PanelContros, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.PanelGrid, 0, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 12)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 155.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1240, 557)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'PanelContros
        '
        Me.PanelContros.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelContros.Controls.Add(Me.btnRefresh)
        Me.PanelContros.Controls.Add(Me.btnExport)
        Me.PanelContros.Controls.Add(Me.cmbAU)
        Me.PanelContros.Controls.Add(Me.cmbRev)
        Me.PanelContros.Controls.Add(Me.lblTWIP)
        Me.PanelContros.Controls.Add(Me.cmbWIP)
        Me.PanelContros.Controls.Add(Me.Label1)
        Me.PanelContros.Controls.Add(Me.lblTAU)
        Me.PanelContros.Location = New System.Drawing.Point(3, 3)
        Me.PanelContros.Name = "PanelContros"
        Me.PanelContros.Size = New System.Drawing.Size(1234, 149)
        Me.PanelContros.TabIndex = 0
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(981, 46)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(212, 48)
        Me.btnRefresh.TabIndex = 39
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(242, 36)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(212, 48)
        Me.btnExport.TabIndex = 38
        Me.btnExport.Text = "Export"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'cmbAU
        '
        Me.cmbAU.FormattingEnabled = True
        Me.cmbAU.Location = New System.Drawing.Point(60, 24)
        Me.cmbAU.Name = "cmbAU"
        Me.cmbAU.Size = New System.Drawing.Size(121, 21)
        Me.cmbAU.TabIndex = 32
        '
        'cmbRev
        '
        Me.cmbRev.FormattingEnabled = True
        Me.cmbRev.Location = New System.Drawing.Point(60, 51)
        Me.cmbRev.Name = "cmbRev"
        Me.cmbRev.Size = New System.Drawing.Size(121, 21)
        Me.cmbRev.TabIndex = 33
        '
        'lblTWIP
        '
        Me.lblTWIP.AutoSize = True
        Me.lblTWIP.Location = New System.Drawing.Point(23, 81)
        Me.lblTWIP.Name = "lblTWIP"
        Me.lblTWIP.Size = New System.Drawing.Size(31, 13)
        Me.lblTWIP.TabIndex = 37
        Me.lblTWIP.Text = "WIP:"
        '
        'cmbWIP
        '
        Me.cmbWIP.FormattingEnabled = True
        Me.cmbWIP.Location = New System.Drawing.Point(60, 78)
        Me.cmbWIP.Name = "cmbWIP"
        Me.cmbWIP.Size = New System.Drawing.Size(121, 21)
        Me.cmbWIP.TabIndex = 34
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Rev:"
        '
        'lblTAU
        '
        Me.lblTAU.AutoSize = True
        Me.lblTAU.Location = New System.Drawing.Point(29, 27)
        Me.lblTAU.Name = "lblTAU"
        Me.lblTAU.Size = New System.Drawing.Size(25, 13)
        Me.lblTAU.TabIndex = 35
        Me.lblTAU.Text = "AU:"
        '
        'PanelGrid
        '
        Me.PanelGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelGrid.Controls.Add(Me.lblTOperaciones)
        Me.PanelGrid.Controls.Add(Me.GridOperaciones)
        Me.PanelGrid.Controls.Add(Me.lblRecordsGridOperaciones)
        Me.PanelGrid.Location = New System.Drawing.Point(3, 158)
        Me.PanelGrid.Name = "PanelGrid"
        Me.PanelGrid.Size = New System.Drawing.Size(1234, 396)
        Me.PanelGrid.TabIndex = 1
        '
        'lblTOperaciones
        '
        Me.lblTOperaciones.AutoSize = True
        Me.lblTOperaciones.Location = New System.Drawing.Point(13, 12)
        Me.lblTOperaciones.Name = "lblTOperaciones"
        Me.lblTOperaciones.Size = New System.Drawing.Size(41, 13)
        Me.lblTOperaciones.TabIndex = 13
        Me.lblTOperaciones.Text = "Circuits"
        '
        'GridOperaciones
        '
        Me.GridOperaciones.AllowUserToAddRows = False
        Me.GridOperaciones.AllowUserToDeleteRows = False
        Me.GridOperaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridOperaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridOperaciones.Location = New System.Drawing.Point(14, 28)
        Me.GridOperaciones.Name = "GridOperaciones"
        Me.GridOperaciones.ReadOnly = True
        Me.GridOperaciones.Size = New System.Drawing.Size(1203, 352)
        Me.GridOperaciones.TabIndex = 12
        '
        'lblRecordsGridOperaciones
        '
        Me.lblRecordsGridOperaciones.AutoSize = True
        Me.lblRecordsGridOperaciones.Location = New System.Drawing.Point(156, 12)
        Me.lblRecordsGridOperaciones.Name = "lblRecordsGridOperaciones"
        Me.lblRecordsGridOperaciones.Size = New System.Drawing.Size(59, 13)
        Me.lblRecordsGridOperaciones.TabIndex = 11
        Me.lblRecordsGridOperaciones.Text = "Records: 0"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 581)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "Form1"
        Me.Text = "Circuits"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.PanelContros.ResumeLayout(False)
        Me.PanelContros.PerformLayout()
        Me.PanelGrid.ResumeLayout(False)
        Me.PanelGrid.PerformLayout()
        CType(Me.GridOperaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents PanelContros As Panel
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnExport As Button
    Friend WithEvents cmbAU As ComboBox
    Friend WithEvents cmbRev As ComboBox
    Friend WithEvents lblTWIP As Label
    Friend WithEvents cmbWIP As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblTAU As Label
    Friend WithEvents PanelGrid As Panel
    Friend WithEvents lblTOperaciones As Label
    Friend WithEvents GridOperaciones As DataGridView
    Friend WithEvents lblRecordsGridOperaciones As Label
End Class
