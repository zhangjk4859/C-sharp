Imports System.Data.OleDb

Public Class Form1

    Dim orcon As New OleDbConnection
    Dim ordc As New OleDbCommand
    Dim PS As New OleDbDataAdapter
    Dim ds As New DataSet
    Dim sql As String

    Dim Numstr(2) As String
    REM
    Dim Number(2) As Double
    REM
    Dim Operater As String
    Dim ResultString As String
    REM
    Dim Result As Double
    REM
    Dim Numindex As Integer

    Public Sub InitCalc()
        REM
        Numstr(1) = ""
        Numstr(2) = ""
        Number(1) = 0
        Number(2) = 0
        Result = 0
        ResultString = ""
        Numindex = 1
        Operater = ""
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, _
                        ByVal e As System.EventArgs) Handles MyBase.Load
        REM
        InitCalc()
    End Sub
    REM
    REM
    Private Sub Num1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles Num1.Click, Num2.Click, Num3.Click, Num4.Click, _
            Num5.Click, Num6.Click, Num7.Click, Num8.Click, Num9.Click, Num0.Click
        REM
        REM Microsoft.VisualBasic
        Numstr(Numindex) += Microsoft.VisualBasic.Right(sender.name, 1)
        Label1.Text = Numstr(Numindex)
    End Sub
    Private Sub numdot_click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles NumDot.Click
        If Microsoft.VisualBasic.InStr(Numstr(Numindex), ".") > 0 Then
            Exit Sub
        End If
        Numstr(Numindex) += "."
        Label1.Text = Numstr(Numindex)
    End Sub
    Private Sub Op1_click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles OP1.Click, OP2.Click, OP3.Click, OP4.Click
        If Operater <> "" Then
            Exit Sub
        End If
        If Numstr(1) = "" Then
            Number(1) = 0
        Else
            Number(1) = Convert.ToDouble(Numstr(Numindex))
        End If
        Numindex = 2
        REM
        Select Case sender.name
            Case "OP1" : Operater = "+"
            Case "OP2" : Operater = "-"
            Case "OP3" : Operater = "*"
            Case "OP4" : Operater = "/"
        End Select
    End Sub

    Private Sub numCE_click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles NumCE.Click
        Numstr(1) = ""
        Numstr(2) = ""
        Operater = ""
        Numindex = 1
        Label1.Text = "0"
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label1_Click_1(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Equation_Click(sender As Object, e As EventArgs) Handles Equation.Click
        If Operater = "" Or Numstr(2) = "" Then
            Exit Sub
        End If
        Number(2) = Convert.ToDouble(Numstr(2))
        Select Case Operater
            Case "+"
                Result = Number(1) + Number(2)
            Case "-"
                Result = Number(1) - Number(2)
            Case "*"
                Result = Number(1) * Number(2)
            Case "/"
                If Number(2) = 0 Then
                    REM
                    MsgBox("除数不能为0", MsgBoxStyle.Exclamation, "错误")
                    Exit Sub
                End If
                Result = Number(1) / Number(2)
        End Select
        Label1.Text = Result.ToString
        Numstr(1) = ""
        Numstr(2) = ""
        Operater = ""
        Numindex = 1
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim constr As String
        constr = "Provider =OraOLEDB.Oracle;Persist Security Info=true;User ID =system;Password =man12afda;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.2.194)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=topprod)))"
        Dim INVMB1 As New DataTable

        Dim PM As String
        sql = "select occ01,occ02,occud05  from zc.occ_file  where occ01='101002'"

        orcon = New OleDbConnection(constr)

        orcon.Open()
     

        PS = New OleDbDataAdapter(sql, orcon)
        orcon.Close()
        PS.Fill(INVMB1) '填充表
        If INVMB1.Rows.Count > 0 Then
            PM = INVMB1.Rows(0)("occ01").ToString.Trim
            MsgBox(PM)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub
End Class
