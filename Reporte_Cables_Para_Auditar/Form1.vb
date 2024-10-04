Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.String
Public Class Form1
    'Dim strCnn As String = "Server=SHPLAPSIS01\SQLEXPRESS2012; Database=SEA; User ID=sa;Password=SHPadmin14%"
    Dim strCnn As String = "Server=10.17.182.12\SQLEXPRESS2012;Database=SEA;User ID=sa;Password=SHPadmin14%"
    Dim cnn As New SqlConnection(strCnn)
    Private TW As New DataTable 'Tabla para el Reporte 
    Private TC As New DataTable 'Tabla para Colores
    Private Sub GeneraColumnas()
        With TW
            .Columns.Add("Circuit", Type.GetType("System.String"))
            .Columns.Add("WID", Type.GetType("System.Int32"))
            .Columns.Add("CP", Type.GetType("System.String"))
            .Columns.Add("Wire", Type.GetType("System.String"))
            .Columns.Add("Color", Type.GetType("System.String"))
            .Columns.Add("JoinA", Type.GetType("System.String"))
            .Columns.Add("JoinB", Type.GetType("System.String"))
            .Columns.Add("WIP", Type.GetType("System.String"))
            .Columns.Add("AU", Type.GetType("System.Int64"))
            .Columns.Add("Rev", Type.GetType("System.String"))
            .Columns.Add("Qty", Type.GetType("System.Int32"))
            .Columns.Add("Notes", Type.GetType("System.String"))
        End With
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        GeneraColumnas()
        CargaAU()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub cmbAU_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAU.SelectedIndexChanged
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        If cmbAU.Text <> "" Then CargaRev(cmbAU.Text)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub cmbRev_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRev.SelectedIndexChanged
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        If cmbRev.Text <> "" Then CargaWIP(cmbAU.Text, cmbRev.Text)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub cmbWIP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbWIP.SelectedIndexChanged
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        If cmbWIP.Text <> "" Then CargaOperacionesWIP(cmbWIP.Text)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim FormReporteAging As New frmReporte(TW)
        FormReporteAging.Show()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        cmbAU.Text = ""
        cmbRev.Text = ""
        cmbWIP.Text = ""
        CargaAU()
        TW.Clear()
        With GridOperaciones
            .DataSource = TW
            .AutoResizeColumns()
        End With
        lblRecordsGridOperaciones.Text = "Records: " + TW.Rows.Count.ToString
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub GridOperaciones_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridOperaciones.CellContentClick
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub
    Private Sub GridOperaciones_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridOperaciones.CellClick
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub
    Private Sub GridOperaciones_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridOperaciones.CellDoubleClick
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub CargaAU()
        Dim Edo As String
        cmbAU.Items.Clear()
        cmbRev.Items.Clear()
        cmbWIP.Items.Clear()
        Using TN As New Data.DataTable 'Despliega los materiales 
            Dim Query As String = "SELECT DISTINCT tblWIP.AU
FROM tblWIP INNER JOIN tblWipDet ON tblWIP.WIP = tblWipDet.WIP
WHERE (tblWIP.Status = N'Open') AND (tblWIP.KindOfAU = 'Only Master CC' OR tblWIP.KindOfAU = N'MasterCC And Cord') AND (tblWIP.wSort > 1) AND (tblWipDet.CWO <> '0')
ORDER BY tblWIP.AU "
            Try
                Dim dr As SqlDataReader
                Dim cmd As SqlCommand = New SqlCommand(Query, cnn)
                'cmd.CommandType = CommandType.Text
                'cmd.Parameters.Add("@Valor1", SqlDbType.NVarChar).Value = ValorStatus
                'cmd.Parameters.Add("@Category", SqlDbType.NVarChar).Value = TipoCategoria
                cnn.Open()
                dr = cmd.ExecuteReader
                TN.Load(dr) ''Llena la tabla
                Edo = cnn.State.ToString
                cnn.Close()
                If TN.Rows.Count > 0 Then
                    Dim AU As Long
                    For i As Integer = 0 To TN.Rows.Count - 1
                        AU = CLng(Val(TN.Rows(i).Item("AU").ToString))
                        cmbAU.Items.Add(AU)
                    Next
                End If
            Catch ex As Exception
                Edo = cnn.State.ToString
                If Edo = "Open" Then cnn.Close()
                MessageBox.Show(ex.Message.ToString + "Error loading AUs", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub CargaRev(ByVal AU As Long)
        Dim Edo As String
        cmbRev.Items.Clear()
        cmbRev.Text = ""
        cmbWIP.Items.Clear()
        cmbWIP.Text = ""
        Using TN As New Data.DataTable
            Dim Query As String = "SELECT DISTINCT tblWIP.Rev
FROM tblWIP INNER JOIN tblWipDet ON tblWIP.WIP = tblWipDet.WIP
WHERE (tblWIP.AU=@AU) AND (tblWIP.Status = N'Open') AND (tblWIP.KindOfAU = 'Only Master CC' OR tblWIP.KindOfAU = N'MasterCC And Cord') AND (tblWIP.wSort > 1) AND (tblWipDet.CWO <> '0')
ORDER BY tblWIP.Rev "
            Try
                Dim dr As SqlDataReader
                Dim cmd As SqlCommand = New SqlCommand(Query, cnn)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@AU", SqlDbType.BigInt).Value = AU
                'cmd.Parameters.Add("@Category", SqlDbType.NVarChar).Value = TipoCategoria
                cnn.Open()
                dr = cmd.ExecuteReader
                TN.Load(dr) ''Llena la tabla
                Edo = cnn.State.ToString
                cnn.Close()
                If TN.Rows.Count > 0 Then
                    Dim Rev As String
                    For i As Integer = 0 To TN.Rows.Count - 1
                        Rev = TN.Rows(i).Item("Rev").ToString
                        cmbRev.Items.Add(Rev)
                    Next
                End If
            Catch ex As Exception
                Edo = cnn.State.ToString
                If Edo = "Open" Then cnn.Close()
                MessageBox.Show(ex.Message.ToString + "Error loading Revs", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub CargaWIP(ByVal AU As Long, ByVal Rev As String)
        Dim Edo As String
        cmbWIP.Items.Clear()
        cmbWIP.Text = ""
        Using TN As New Data.DataTable
            Dim Query As String = "SELECT DISTINCT tblWIP.WIP
FROM tblWIP INNER JOIN tblWipDet ON tblWIP.WIP = tblWipDet.WIP
WHERE (tblWIP.AU=@AU) AND (tblWIP.Rev=@Rev) AND (tblWIP.Status = N'Open') AND (tblWIP.KindOfAU = 'Only Master CC' OR tblWIP.KindOfAU = N'MasterCC And Cord') AND (tblWIP.wSort > 1) AND (tblWipDet.CWO <> '0')
ORDER BY tblWIP.WIP "
            Try
                Dim dr As SqlDataReader
                Dim cmd As SqlCommand = New SqlCommand(Query, cnn)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@AU", SqlDbType.BigInt).Value = AU
                cmd.Parameters.Add("@Rev", SqlDbType.NVarChar).Value = Rev
                cnn.Open()
                dr = cmd.ExecuteReader
                TN.Load(dr) ''Llena la tabla
                Edo = cnn.State.ToString
                cnn.Close()
                If TN.Rows.Count > 0 Then
                    Dim WIP As String
                    For i As Integer = 0 To TN.Rows.Count - 1
                        WIP = TN.Rows(i).Item("WIP").ToString
                        cmbWIP.Items.Add(WIP)
                    Next
                End If
            Catch ex As Exception
                Edo = cnn.State.ToString
                If Edo = "Open" Then cnn.Close()
                MessageBox.Show(ex.Message.ToString + "Error loading WIPs", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub CargaOperacionesWIP(ByVal WIP As String)
        Dim Edo As String
        TW.Clear()
        TC.Clear()
        CargaColores()
        Using TN As New Data.DataTable
            Dim Query As String = "SELECT tblWipDet.Circuit, tblWipDet.CP, tblWipDet.Wire, tblWipDet.JoinA, tblWipDet.JoinB, tblWipDet.WID, tblWIP.WIP, tblWIP.AU, tblWIP.Rev, tblWIP.Qty, tblWIP.KindOfAU FROM tblWipDet INNER JOIN tblWIP ON tblWipDet.WIP = tblWIP.WIP WHERE (tblWipDet.WIP=@WIP) ORDER BY tblWipDet.WID ASC"
            Try
                Dim dr As SqlDataReader
                Dim cmd As SqlCommand = New SqlCommand(Query, cnn)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@WIP", SqlDbType.NVarChar).Value = WIP
                cnn.Open()
                dr = cmd.ExecuteReader
                TW.Load(dr) ''Llena la tabla
                cnn.Close()
                If TW.Rows.Count > 0 Then
                    lblRecordsGridOperaciones.Text = "Records: " + TW.Rows.Count.ToString
                    If TC.Rows.Count > 0 Then
                        Asignando_Colores()
                    End If
                    With GridOperaciones
                        .DataSource = TW
                        .AutoResizeColumns()
                    End With
                Else
                    MessageBox.Show("No hay hoja de corte para este WIP / There is not cut card for this WIP")
                End If
            Catch ex As Exception
                Edo = cnn.State.ToString
                If Edo = "Open" Then cnn.Close()
                MessageBox.Show(ex.Message.ToString + "Error loading WIPs", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub Asignando_Colores()
        Dim cable, color, aux As String
        For NM As Integer = 0 To TW.Rows.Count - 1
            cable = TW.Rows(NM).Item("Wire").ToString
            aux = Mid(cable, 6)
            color = Busca_El_Color(aux)
            TW.Rows(NM).Item("Color") = color
        Next
    End Sub

    Private Function Busca_El_Color(ByVal Numeros As String)
        Dim Resp As String = "", Aux As String = ""
        Dim ArregloDeColores() As String
        ArregloDeColores = Numeros.Split("-")
        For i As Integer = 0 To UBound(ArregloDeColores)
            Aux = ArregloDeColores(i)
            Aux = Aux.Replace(vbCrLf, " ")
            If i > 0 Then
                Resp += " / "
            End If
            Resp += Identificando_Color(Aux)
            ' MessageBox.Show(ArregloDeColores(i))
        Next i
        Return Resp
    End Function

    Private Function Identificando_Color(ByVal Numero As String)
        Dim Resp As String = ""
        Dim Aux As String = ""
        For NM As Integer = 0 To TC.Rows.Count - 1
            Aux = TC.Rows(NM).Item("Code").ToString
            If Numero = Aux Then
                Resp = TC.Rows(NM).Item("Color").ToString
                NM = TC.Rows.Count - 1
                Resp = Resp.Replace(Chr(9), "")
                Resp = Resp.Replace(vbCrLf, " ")
            End If
        Next
        Return Resp
    End Function
    Private Sub CargaColores()
        Dim Edo As String
        TC.Clear()
        Using TN As New Data.DataTable
            Dim Query As String = "SELECT * FROM tblItemsWireColors "
            Try
                Dim dr As SqlDataReader
                Dim cmd As SqlCommand = New SqlCommand(Query, cnn)
                'cmd.CommandType = CommandType.Text
                'cmd.Parameters.Add("@WIP", SqlDbType.NVarChar).Value = WIP
                cnn.Open()
                dr = cmd.ExecuteReader
                TC.Load(dr) ''Llena la tabla
                cnn.Close()
                If TC.Rows.Count = 0 Then
                    MessageBox.Show("No colors found")
                    Application.Exit()
                End If
            Catch ex As Exception
                Edo = cnn.State.ToString
                If Edo = "Open" Then cnn.Close()
                MessageBox.Show(ex.Message.ToString + "Error loading colors", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub Test()
        Dim LineOfText As String
        Dim i As Integer
        Dim aryTextFile() As String

        LineOfText = "UserName1, Password1, UserName2, Password2"

        aryTextFile = LineOfText.Split(",")

        For i = 0 To UBound(aryTextFile)

            MessageBox.Show(aryTextFile(i))

        Next i
    End Sub
End Class
