Public Class frmReporte
    Private TN As New DataTable
    Sub New(ByVal ta As DataTable)
        Try
            ' This call is required by the designer.
            InitializeComponent()
            TN = ta
            ' Add any initialization after the InitializeComponent() call.
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub frmReporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        'ReportViewer1.ShowExportButton = False
        With Me.ReportViewer1.LocalReport
            .DataSources.Clear()
            .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSetWires", TN))
        End With
        Me.ReportViewer1.RefreshReport()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub
End Class