Imports System.Drawing
Imports System.Windows.Forms
Imports PluginSdk

Public Class FirstView
    Implements IView

    Sub New()

        InitializeComponent()

        ' Imposta la dimensione del UserControl (se necessario)
        Me.Size = New Drawing.Size(400, 300)

        ' Aggiungi un pulsante di esempio al UserControl
        Dim button As New Button()
        button.Text = "Clicca qui"
        button.Location = New Point(100, 100)

        ' Gestisci l'evento di click del pulsante
        AddHandler button.Click, AddressOf Button_Click

        ' Aggiungi il pulsante al UserControl
        Me.Controls.Add(button)

    End Sub

    ' Metodo per gestire il click del pulsante
    Private Sub Button_Click(sender As Object, e As EventArgs)
        MessageBox.Show("Hai cliccato il pulsante nel UserControl!")
    End Sub

End Class
