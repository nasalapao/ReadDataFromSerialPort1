Imports System.IO.Ports

Public Class Form1
    Dim SerialPort1 = New SerialPort()
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connetc_Serial_Port()

    End Sub

    Private Sub Connetc_Serial_Port()
        Try
            ' Create a new SerialPort object with default settings.

            With SerialPort1
                .PortName = "COM2" 'COMPORT
                .BaudRate = 9600
                .Parity = Parity.None
                .DataBits = 8
                .StopBits = 1 'IO.Ports.StopBits.One

                If .IsOpen = True Then .Close()
            End With
            SerialPort1.Open()

        Catch ex As Exception
            MsgBox(" <<<PORT >>>  ไม่พบหรือกำลังเปิดอยู่ กรุณาปิดโปรแกรมอื่นๆก่อนแล้วเปิดโปรแกรมนี้ใหม่อีกครั้ง", MsgBoxStyle.Information)
            Application.Exit()
        End Try

    End Sub




    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim message As String = SerialPort1.ReadLine()
        Label1.Text = message
        Console.WriteLine(message)
    End Sub
End Class
