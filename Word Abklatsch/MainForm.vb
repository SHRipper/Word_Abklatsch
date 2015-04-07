Public Class Word_Abklatsch

    Dim savepath As String
    Dim TextfeldFont As Font

    Private Sub Word_Abklatsch_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TextfeldFont = New Font("Trebuchet MS", 12) 'Standartfont beim Start des Programms

        'Schriftgrößen-Array erstellen und füllen
        Dim Schriftgröße(29) As Object
        For i As Integer = 8 To 30
            Schriftgröße(i - 8) = i
        Next

        ComboBoxSchriftgröße.Text = "Fontgröße auswählen" 'Auswahltext
        ComboBoxSchriftgröße.Items.AddRange(Schriftgröße) 'Combobox mit Schriftgröße-Array füllen
    End Sub

    Private Sub Word_Abklatsch_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        'Textfeldposition
        Textfeld.Width = Me.Width - 300
        Textfeld.Height = Me.Height - (MenuStrip1.Height + 50) - 50
        Textfeld.Location = New Point(150, MenuStrip1.Height + 50)
    End Sub

    Private Sub Fontgrößen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxSchriftgröße.SelectedIndexChanged
        'Neue Font mit benutzerdefinierter Schriftgröße
        Textfeld.Font = New Font("Trebuchet MS", ComboBoxSchriftgröße.SelectedItem)
        
        EinstellungenToolStripMenuItem.HideDropDown() 'Einstellungsmenü einklappen
    End Sub

    Private Sub NeuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NeuToolStripMenuItem.Click
        Dim NewDR As DialogResult = MessageBox.Show("Willst du wirklich ein neues Dokument erstellen?", _
                                                     "Warnung", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
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
            'Wenn noch nicht gespeichert, oder eine Datei geöffnet wurde
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
        Dim CloseDR As DialogResult = MessageBox.Show("Willst du das Programm wirklich schließen?", _
                                                      "Warnung", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
        If CloseDR = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
    End Sub
End Class
