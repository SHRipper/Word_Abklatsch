Public Class Word_Abklatsch

    'Variablen der Klasse "Word_Abklatsch"
    Dim savepath As String

    Private Sub Word_Abklatsch_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Fontgrößen Combobox füllen

    End Sub

    Private Sub Fontgrößen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Fontgrößen.SelectedIndexChanged

    End Sub

    Private Sub NeuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NeuToolStripMenuItem.Click
        Dim NewDR As DialogResult = MessageBox.Show("Willst du wirklich ein neues Dokument erstellen?", "Warnung", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
        If NewDR = Windows.Forms.DialogResult.Yes Then
            Textfeld.Clear()
        End If
    End Sub

    Private Sub ÖffnenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ÖffnenToolStripMenuItem.Click
        Dim OpenDialog As New OpenFileDialog
        OpenDialog.InitialDirectory = Environment.SpecialFolder.MyDocuments
        OpenDialog.Title = "Öffnen..."
        OpenDialog.Filter = "Textdatei | *.txt" 'Nur Dateien mit Endung ".txt" anzeigen
        OpenDialog.ShowDialog() 'Dialog anzeigen

        savepath = OpenDialog.FileName 'Speicherpfad ist gleich dem Pfad der geöffneten Datei
        Textfeld.Text = IO.File.ReadAllText(savepath) 'Text aus Datei in Textfeld einfügen
    End Sub

    Private Sub SpeichernToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SpeichernToolStripMenuItem.Click
        If savepath = "" Then
            Speichern_unter()
        Else
            Speichern()
        End If
    End Sub

    Private Sub SpeichernUnterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SpeichernUnterToolStripMenuItem.Click
        Speichern_unter()
    End Sub

    Private Sub Speichern_unter()
        Dim SaveAsDialog As New SaveFileDialog
        SaveAsDialog.InitialDirectory = Environment.SpecialFolder.MyDocuments
        SaveAsDialog.Title = "Speichern unter..."
        SaveAsDialog.Filter = "Textdatei | *.txt" 'Nur Textdateien anzeigen
        SaveAsDialog.ShowDialog() 'Dialog anzeigen

        SaveAsDialog.FileName = savepath 'Pfad der Datei soll nun "savepath" sein
        IO.File.WriteAllText(savepath, Textfeld.Text) 'Inhalt des Textfeldes in die Datei schreiben
    End Sub

    Private Sub Speichern()
        IO.File.WriteAllText(savepath, Textfeld.Text) 'Inhalt des Textfeldes in die Datei schreiben
    End Sub

    Private Sub SchließenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SchließenToolStripMenuItem.Click
        Dim CloseDR As DialogResult = MessageBox.Show("Willst du das Programm wirklich schließen?", "Warnung", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
        If CloseDR = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
    End Sub


End Class
