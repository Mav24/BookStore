' Name Book Store
' Purpose: School Project
' Programmer: Murray Duke June 23th 2019

Option Explicit On
Option Strict On
Option Infer Off

Public Class MainForm
    Dim totalDue As Double

    Private Sub BtnAddToTotal_Click(sender As Object, e As EventArgs) Handles btnAddToTotal.Click
        ' Declare Veriables
        Dim quantity As Integer
        Dim price As Double

        ' Assign veriables
        Integer.TryParse(txtQuantity.Text, quantity)
        Double.TryParse(txtPrice.Text, price)

        If String.IsNullOrWhiteSpace(txtQuantity.Text) Then
            MessageBox.Show("Please fill out quantity text box!", "Missing", MessageBoxButtons.OK)
            txtQuantity.Focus()
        ElseIf String.IsNullOrWhiteSpace(txtPrice.Text) Then
            MessageBox.Show("Please fill out Price text box with an numeric only", "Missing", MessageBoxButtons.OK)
            txtQuantity.Focus()
        Else
            totalDue += quantity * price
            lblTotalDue.Text = totalDue.ToString("C")
            ClearTextBoxes()
        End If

    End Sub
    Private Sub ClearTextBoxes()
        txtPrice.Text = String.Empty
        txtQuantity.Text = String.Empty
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub BtnNewOrder_Click(sender As Object, e As EventArgs) Handles btnNewOrder.Click
        lblTotalDue.Text = String.Empty
        totalDue = 0.0
    End Sub

    Private Sub NumbersOnly_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQuantity.KeyPress, txtPrice.KeyPress
        ' Accept only numbers, The period and the backspace key.
        If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso e.KeyChar <> "." AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub
End Class
