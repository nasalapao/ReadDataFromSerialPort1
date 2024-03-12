Imports System.IO.Ports
Imports System.Threading
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form1


    Dim mySerialPort As New SerialPort("COM2", 9600, Parity.None, 8, StopBits.One)


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            mySerialPort.Open()
            AddHandler mySerialPort.DataReceived, AddressOf data
        Catch ex As Exception
            MessageBox.Show("Error opening serial port: " & ex.Message)
        End Try

    End Sub
    Private Sub data(sender As Object, e As SerialDataReceivedEventArgs)
        Dim receivedData As String = mySerialPort.ReadLine()
        Console.WriteLine(receivedData)
        SetText(receivedData)


    End Sub

    Delegate Sub SetTextCallback(ByVal text As String)

    Private Sub SetText(ByVal text As String)
        If Me.Label1.InvokeRequired Then
            Dim d As SetTextCallback = New SetTextCallback(AddressOf SetText)
            Me.Invoke(d, New Object() {text})
        Else
            Me.Label1.Text = text
        End If
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        mySerialPort.Close()
    End Sub
End Class
