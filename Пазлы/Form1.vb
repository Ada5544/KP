Public Class Form1
    Dim CurrPBox As PictureBox
    Dim Dest_PB As PictureBox
    Dim Canv1 As New List(Of PictureBox)
    Dim Canv2 As New List(Of PictureBox)
    Dim P_Width As Integer = 3
    Dim P_Height As Integer = 2
    Dim C_Width, C_Height As Integer
    Dim pt As Point
    Dim R As New Random
    Dim Pictures As New List(Of String)
    Dim Level As Integer = 0
    Dim Hint, Saper As Boolean
    Dim CanMoveNewPicture As Boolean = True

    Public Declare Function LockWindowUpdate Lib "user32" (ByVal hWnd As IntPtr) As Integer

    Private Sub pb_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            sender.Location = New Point(sender.Location.X + e.X - pt.X, sender.Location.Y + e.Y - pt.Y)
        End If
    End Sub

    Function Inters(ByRef PB1 As PictureBox, ByVal PB2 As PictureBox) As Boolean
        If PB1.Bounds.IntersectsWith(PB2.Bounds) Then
            Dim R As Rectangle = Rectangle.Union(PB1.Bounds, PB2.Bounds)
            If R.Width - PB1.Width < C_Width / 2 And R.Height - PB1.Height < C_Height / 2 Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Function Vect(ByVal PB1 As PictureBox, ByVal PB2 As PictureBox) As Integer()
        Dim D(1) As Integer
        If PB1.Top > PB2.Top Then D(0) = 1
        If PB1.Top < PB2.Top Then D(0) = -1
        If PB1.Left > PB2.Left Then D(1) = 1
        If PB1.Left < PB2.Left Then D(1) = -1
        Return D
    End Function

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        CanMoveNewPicture = False

        Dim Stp As Integer
        If Inters(Dest_PB, CurrPBox) = True Then
            Stp = 3
        Else
            Stp = 5
        End If

        If Dest_PB.Top <> CurrPBox.Top Then
            CurrPBox.Top += Vect(Dest_PB, CurrPBox)(0) * Stp
            '//
            If Math.Abs(Dest_PB.Top - CurrPBox.Top) < 4 Then
                CurrPBox.Top = Dest_PB.Top
            End If
        End If
        If Dest_PB.Left <> CurrPBox.Left Then
            CurrPBox.Left += Vect(Dest_PB, CurrPBox)(1) * Stp
            '//
            If Math.Abs(Dest_PB.Left - CurrPBox.Left) < 4 Then
                CurrPBox.Left = Dest_PB.Left
            End If
        End If
        If Dest_PB.Top = CurrPBox.Top AndAlso Dest_PB.Left = CurrPBox.Left Then
            CanMoveNewPicture = True
            Snd("inst.wav")
            Timer1.Stop()
            CheckOK(Dest_PB, CurrPBox)
            If Saper = True AndAlso CheckOK(Dest_PB, CurrPBox) = False Then
                MsgBox("Ход неверный, Вы проиграли. До новых встреч", MsgBoxStyle.Critical)
                Close()
                Exit Sub
            End If
            If Hint = True Then
                If CheckOK(Dest_PB, CurrPBox) = False Then
                    PictureBox1.BackgroundImage = My.Resources.no
                Else
                    PictureBox1.BackgroundImage = My.Resources.yes
                End If
                PictureBox1.Visible = True : Timer2.Stop() : Timer2.Start()
            End If
            ChkVictory()
        End If
    End Sub


    Sub Snd(ByVal fName As String)
        Try
            My.Computer.Audio.Play(Application.StartupPath & "\Sounds\" & fName, AudioPlayMode.Background)
        Catch ex As Exception
            MsgBox(ErrorToString)
        End Try
    End Sub

    Sub ChkVictory()
        Dim Succ As Integer = 0

        For I As Integer = 0 To Canv1.Count - 1
            If Controls("PB1_" & I).Location = Controls("PB2_" & I).Location Then Succ += 1
        Next

        If Succ = P_Width * P_Height Then
            For Each C_Pb As PictureBox In Canv2
                C_Pb.Image = Nothing

                If Pictures.Count = 0 Then
                    Snd("victory.wav")
                    Me.Opacity = 0.5
                    Form3.ShowDialog()
                    Close()
                    Exit For
                    Exit Sub
                Else
                    Snd("level_comlete.wav")
                    Button1.BringToFront()
                    Button1.Visible = True
                End If
            Next
        End If
    End Sub


    'Dim B As New Bitmap("C:\1.png")
    Function CheckOK(ByVal PB1 As PictureBox, ByVal PB2 As PictureBox) As Boolean
        If PB1.Name.Replace("PB1_", "") = PB2.Name.Replace("PB2_", "") Then
            'PB2.Image = B
            Return True
        End If
        Return False
    End Function

    Class Pazl
        Public BM As Bitmap
        Public Name As Integer
    End Class

    Sub NewGame()

        Dim TmpPic As Integer = R.Next(0, Pictures.Count)
        Dim BM As New Bitmap(Pictures(TmpPic))
        Pictures.RemoveAt(TmpPic)

        Dim Prew As New Form2
        Prew.PictureBox1.Image = BM
        Prew.PictureBox1.Size = BM.Size
        Prew.ShowDialog()

        LockWindowUpdate(Me.Handle)
        For Each PB As PictureBox In Canv1
            PB.Dispose()
        Next
        Canv1.Clear()
        For Each PB As PictureBox In Canv2
            PB.Dispose()
        Next
        Canv2.Clear()


        Dim Coeff As Double = BM.Width / BM.Height

        P_Width = Level + 3
        P_Height = P_Width / Coeff

        C_Width = BM.Width / P_Width
        C_Height = BM.Height / P_Height

        Dim CorrectWidth As Integer = 0
        Dim CorrectHeight As Integer = 0
        If BM.Width < P_Width * C_Width Then CorrectWidth = P_Width * C_Width - BM.Width
        If BM.Height < P_Height * C_Height Then CorrectHeight = P_Height * C_Height - BM.Height
        If CorrectHeight > 0 Or CorrectWidth > 0 Then
            BM = New Bitmap(BM, New Size(BM.Width + CorrectWidth, BM.Height + CorrectHeight))
        End If

        Dim Pz As New List(Of Pazl)
        For X As Integer = 0 To P_Width - 1
            For Y As Integer = 0 To P_Height - 1
                Pz.Add(New Pazl With {.BM = BM.Clone(New Rectangle(X * C_Width, Y * C_Height, C_Width, C_Height), BM.PixelFormat), .Name = Pz.Count})
            Next
        Next

        Dim Border As New Bitmap(C_Width, C_Height)
        Dim G As Graphics = Graphics.FromImage(Border)
        G.DrawRectangle(Pens.LightGray, New Rectangle(0, 0, Border.Width, Border.Height))

        Dim _Name As Integer = 0

        For X As Integer = 0 To P_Width - 1
            For Y As Integer = 0 To P_Height - 1
                Dim PB As New PictureBox With {.Left = 15 + X * C_Width, .Width = C_Width, .Height = C_Height, .Top = 55 + Y * C_Height, .Parent = Me, .BackColor = Color.FromArgb(150, 70, 50, 50), .Image = Border, .Name = "PB1_" & _Name}
                Canv1.Add(PB)
                _Name += 1
            Next
        Next
        Dim TmpRnd As Integer
        For X As Integer = 0 To P_Width - 1
            For Y As Integer = 0 To P_Height - 1
                TmpRnd = R.Next(0, Pz.Count)
                Dim PB As New PictureBox With {.Left = 15 + X * (C_Width + 1), .Width = C_Width, .Height = C_Height, .Top = BM.Height + 90 + Y * (C_Height + 1), .Parent = Me, .Image = Border, .BackColor = Color.Aqua, .Name = "PB2_" & Pz(TmpRnd).Name}
                Canv2.Add(PB)
                AddHandler PB.MouseMove, AddressOf pb_MouseMove
                AddHandler PB.MouseDown, AddressOf PictureBox_MouseDown
                AddHandler PB.MouseUp, AddressOf PictureBox_MouseUp
                PB.BackgroundImage = Pz(TmpRnd).BM
                Pz.RemoveAt(TmpRnd)
            Next
        Next
        'Me.Width = BM.Width + 50
        'Me.Height = BM.Height * 2 + 200
        LockWindowUpdate(IntPtr.Zero)
        Snd("next_level.wav")
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Pictures.AddRange(IO.Directory.GetFiles(Application.StartupPath & "\Pictures", "*.jpg"))
        NewGame()
    End Sub

    Private Sub PictureBox_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        sender.BringToFront()
        pt = New Point(e.X, e.Y)
    End Sub

    Private Sub PictureBox_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If CanMoveNewPicture = True Then
            CurrPBox = sender
        End If


        For Each P As PictureBox In Canv1
            If Inters(CurrPBox, P) = True Then
                Dest_PB = P
                Timer1.Start()
            End If
        Next
        If CurrPBox.Left > Me.Width Then
            Do While CurrPBox.Left > Width - CurrPBox.Width
                CurrPBox.Left -= 1
                Application.DoEvents()
            Loop

        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Level < 4 Then Level += 1
        NewGame()
        Button1.Visible = False
    End Sub

    Private Sub Button1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button1.MouseDown
        Button1.BackgroundImage = My.Resources.next2
    End Sub

    Private Sub Button1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button1.MouseUp
        Button1.BackgroundImage = My.Resources._next
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        PictureBox1.Visible = False
    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        Dim Stp As Integer
        If Inters(Dest_PB, CurrPBox) = True Then
            Stp = 2
        Else
            Stp = 5
        End If
        If Dest_PB.Top <> CurrPBox.Top Then
            CurrPBox.Top += Vect(Dest_PB, CurrPBox)(0) * Stp
            If Math.Abs(Dest_PB.Top - CurrPBox.Top) < 3 Then
                CurrPBox.Top = Dest_PB.Top
            End If
        End If
        If Dest_PB.Left <> CurrPBox.Left Then
            CurrPBox.Left += Vect(Dest_PB, CurrPBox)(1) * Stp
            If Math.Abs(Dest_PB.Left - CurrPBox.Left) < 3 Then
                CurrPBox.Left = Dest_PB.Left
            End If
        End If
        If Dest_PB.Top = CurrPBox.Top AndAlso Dest_PB.Left = CurrPBox.Left Then
            Snd("inst.wav")
            Timer3.Stop()
            ChkVictory()
            ShowMasterClass()
        End If
    End Sub

    Private Sub ShowMasterClass()
        For Each PB As PictureBox In Canv2
            If PB.Top > P_Height * C_Height + 50 Then
                CurrPBox = PB
                CurrPBox.BringToFront()
                Dest_PB = Controls("PB1_" & PB.Name.Replace("PB2_", ""))
                Timer3.Start()
                Exit For
            End If
        Next
    End Sub

    Private Sub ПказыватьПодсказкиToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ПказыватьПодсказкиToolStripMenuItem.Click
        Hint = ПказыватьПодсказкиToolStripMenuItem.Checked
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        ПказыватьПодсказкиToolStripMenuItem.Checked = Hint
        РежимсаперабезПраваНаОшибкуToolStripMenuItem.Checked = Saper
    End Sub

    Private Sub РежимсаперабезПраваНаОшибкуToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles РежимсаперабезПраваНаОшибкуToolStripMenuItem.Click
        Saper = РежимсаперабезПраваНаОшибкуToolStripMenuItem.Checked
        If Hint = True And Saper = True Then Hint = False
        ПоказатьКакНужноСобратьКартинкуToolStripMenuItem.Enabled = Not Saper
    End Sub

    Private Sub ПоказатьКакНужноСобратьКартинкуToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ПоказатьКакНужноСобратьКартинкуToolStripMenuItem.Click
        For Each PB As PictureBox In Canv2
            RemoveHandler PB.MouseMove, AddressOf pb_MouseMove
            RemoveHandler PB.MouseDown, AddressOf PictureBox_MouseDown
            RemoveHandler PB.MouseUp, AddressOf PictureBox_MouseUp
        Next
        ShowMasterClass()
    End Sub
End Class
