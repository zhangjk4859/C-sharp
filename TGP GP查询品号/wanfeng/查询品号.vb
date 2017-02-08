Imports System.Data.OleDb
Public Class 查询品号
    Dim orcon As New OleDbConnection
    Dim ordc As New OleDbCommand
    Dim PS As New OleDbDataAdapter
    Dim ds As New DataSet
    Dim sql As String
    Dim constr As String = "Provider =OraOLEDB.Oracle;Persist Security Info=true;User ID =system;Password =manager;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.2.194)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=topprod)))"

    Private Sub 查询品号_Load(sender As Object, e As EventArgs) Handles MyBase.Load
     
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim INVMB1 As New DataTable
        If CheckBox1.Checked = False Then
            sql = "select ima01,ima02,ima021,imaud03,'','','',ima35  from zc.ima_file  where (ima01 like '%" & TextBox1.Text & "%' or ima02 like '%" & TextBox1.Text & "%' or ima021 like '%" & TextBox1.Text & "%' ) and imaacti='Y'  and （ima01 like '1%' or ima01 like '2%' or ima01 like '3%' or ima01 like '4%')  order by ima01"
        Else
            sql = "select ima01,ima02,ima021,imaud03,occ02,obk03,ta_obk01,ima35  from zc.ima_file left join zc.obk_file on obk01=ima01 left join zc.occ_file on occ01=obk02  where  (ima01 like '%" & TextBox1.Text & "%' or ima02 like '%" & TextBox1.Text & "%' or ima021 like '%" & TextBox1.Text & "%' OR obk03 like '%" & TextBox1.Text & "%'  OR ta_obk01 like '%" & TextBox1.Text & "%' )  and imaacti='Y' and （ima01 like '1%' or ima01 like '2%' or ima01 like '3%' or ima01 like '4%') and obk03 is not null  and obk03<>' ' order by ima01"
        End If
        orcon = New OleDbConnection(constr)
        orcon.Open()
        PS = New OleDbDataAdapter(sql, orcon)
        orcon.Close()
        PS.Fill(INVMB1) '填充表
        DataGridView1.DataSource = INVMB1
        DataGridView1.Columns(0).HeaderText = "品号"


        DataGridView1.Columns(1).HeaderText = "品名"


        DataGridView1.Columns(2).HeaderText = "规格"

        DataGridView1.Columns(3).HeaderText = "模具号"

        DataGridView1.Columns(4).HeaderText = "客户名称"

        DataGridView1.Columns(5).HeaderText = "客户品号"

        DataGridView1.Columns(6).HeaderText = "客户品名"

        DataGridView1.Columns(7).HeaderText = "主要仓库"
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Dim INVMB1 As New DataTable
        If CheckBox1.Checked = False Then
            sql = "select ima01,ima02,ima021,imaud03,'','','',ima35  from zc.ima_file  where ima01 like '" & TextBox2.Text & "%' and imaacti='Y'  and （ima01 like '1%' or ima01 like '2%' or ima01 like '3%' or ima01 like '4%')   order by ima01"
        Else
            sql = "select ima01,ima02,ima021,imaud03,occ02,obk03,ta_obk01,ima35  from zc.ima_file left join zc.obk_file on obk01=ima01 left join zc.occ_file on occ01=obk02  where ima01 like '" & TextBox2.Text & "%' and imaacti='Y' and （ima01 like '1%' or ima01 like '2%' or ima01 like '3%' or ima01 like '4%') and obk03 is not null  and obk03<>' ' order by ima01"
        End If
        orcon = New OleDbConnection(constr)
        orcon.Open()
        PS = New OleDbDataAdapter(sql, orcon)
        orcon.Close()
        PS.Fill(INVMB1) '填充表
        DataGridView1.DataSource = INVMB1
        DataGridView1.Columns(0).HeaderText = "品号"


        DataGridView1.Columns(1).HeaderText = "品名"


        DataGridView1.Columns(2).HeaderText = "规格"

        DataGridView1.Columns(3).HeaderText = "模具号"

        DataGridView1.Columns(4).HeaderText = "客户名称"

        DataGridView1.Columns(5).HeaderText = "客户品号"

        DataGridView1.Columns(6).HeaderText = "客户品名"

        DataGridView1.Columns(7).HeaderText = "主要仓库"
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        Dim INVMB1 As New DataTable
        If CheckBox1.Checked = False Then
            sql = "select ima01,ima02,ima021,imaud03,'','','',ima35  from zc.ima_file  where imaud03 like '%" & TextBox3.Text & "%' and imaacti='Y'  and （ima01 like '1%' or ima01 like '2%' or ima01 like '3%' or ima01 like '4%')  order by ima01"
        Else
            sql = "select ima01,ima02,ima021,imaud03,occ02,obk03,ta_obk01,ima35  from zc.ima_file left join zc.obk_file on obk01=ima01 left join zc.occ_file on occ01=obk02  where imaud03 like '%" & TextBox3.Text & "%' and imaacti='Y' and （ima01 like '1%' or ima01 like '2%' or ima01 like '3%' or ima01 like '4%') and obk03 is not null  and obk03<>' ' order by ima01"
        End If
        orcon = New OleDbConnection(constr)
        orcon.Open()
        PS = New OleDbDataAdapter(sql, orcon)
        orcon.Close()
        PS.Fill(INVMB1) '填充表
        DataGridView1.DataSource = INVMB1
        DataGridView1.Columns(0).HeaderText = "品号"


        DataGridView1.Columns(1).HeaderText = "品名"


        DataGridView1.Columns(2).HeaderText = "规格"

        DataGridView1.Columns(3).HeaderText = "模具号"

        DataGridView1.Columns(4).HeaderText = "客户名称"

        DataGridView1.Columns(5).HeaderText = "客户品号"

        DataGridView1.Columns(6).HeaderText = "客户品名"

        DataGridView1.Columns(7).HeaderText = "主要仓库"
    End Sub
End Class