Imports System.IO

Public Class Form1
    Private Sub btnOpenFile_Click(sender As Object, e As EventArgs) Handles btnOpenFile.Click
        OpenFileDialog1.Filter = "Excel,Word|*.xls;*.xlsx;*.Doc;*.Docx"
        OpenFileDialog1.ShowDialog()
        txtUrlFile.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub btnKata_Click(sender As Object, e As EventArgs) Handles btnKata.Click
        If String.IsNullOrWhiteSpace(txtUrlFile.Text) Then
            MessageBox.Show("pilih file terlebih dahulu !", "Anda belum memilih file", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            hitungKata(txtUrlFile.Text)
        End If
    End Sub

    Private Sub btnBaris_Click(sender As Object, e As EventArgs) Handles btnBaris.Click
        If String.IsNullOrWhiteSpace(txtUrlFile.Text) Then
            MessageBox.Show("pilih file terlebih dahulu !", "Anda belum memilih file", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Dim namaFile As String = txtUrlFile.Text
            If File.Exists(namaFile) Then
                Dim baris() As String = File.ReadAllLines(namaFile)
                dataView("jumlah baris", baris.Length)
            Else
                MessageBox.Show("file tidak di temukan", "error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Function hitungKata(ByVal namaFile As String)
        Dim jumlahKata As Integer = 0
        If File.Exists(namaFile) Then
            Using sr As New StreamReader(namaFile)
                Dim baris As String
                Do
                    baris = sr.ReadLine()
                    If baris IsNot Nothing Then
                        jumlahKata += baris.Split(" "c).Length
                    End If
                Loop Until baris Is Nothing
                sr.Close()
            End Using
            dataView("Jumlah kata", jumlahKata)
        Else
            MessageBox.Show("file tidak di temukan", "error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Return jumlahKata
    End Function

    Function dataView(ByVal keterangan As String, ByVal jumlah As Integer)
        Dim dt As New DataTable()
        dt.Columns.Add("Keterangan")
        dt.Columns.Add("jumlah")

        dt.Rows.Add(keterangan, jumlah)

        dgview.DataSource = dt
        dgview.Columns(0).Width = 187
        dgview.Columns(1).Width = 150

    End Function


    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtUrlFile.Clear()
        dgview.DataSource = Nothing
        dgview.Rows.Clear()
        dgview.Columns.Clear()
    End Sub

End Class
