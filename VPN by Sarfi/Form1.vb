Imports System.Net
Imports System.Net.Http
Imports System.Net.NetworkInformation
Imports System.Net.Sockets
Imports System.Reflection.Emit
Imports System.Windows
Imports System.Windows.Forms.DataFormats



Public Class Form1
    Private ipAddress As String
    Private httpClient As HttpClient
    Private Sub NavServersBtn_Click(sender As Object, e As EventArgs) Handles NavServersBtn.Click
        NavServers()
        hide_MainPage()

        showSeversPage()
    End Sub
    Private Sub NavServersBtnClicked_Click(sender As Object, e As EventArgs) Handles NavServersBtnClicked.Click
        NavServers()
        hide_MainPage()
        showSeversPage()
    End Sub



    Public Sub NavServers()
        NavHomeBtn.Visible = True
        NavHomeBtnClicked.Visible = False
        NavServersBtn.Visible = False
        NavServersBtnClicked.Visible = True
        NavStreamingBtn.Visible = True
        NavStreamingBtnClicked.Visible = False
        NavSocialBtn.Visible = True
        NavSocialBtnClicked.Visible = False




    End Sub

    Public Sub hide_MainPage()
        ConnectionImage.Visible = False
        NotConnectionImage.Visible = False

        imageBoxLINE.Visible = False

        ConnectedTitle.Visible = False
        NotConnectedTitle.Visible = False

        BottomElementBg.Visible = False
        bottomBox.Visible = False

        ConnectionImage.Visible = False

        ipImg.Visible = False
        serverImg.Visible = False

        CheckLocationBtn.Visible = False
        ChangeServerBtn.Visible = False




    End Sub


    Public Sub Show_MainPage()
        'ConnectionImage.Visible = False
        NotConnectionImage.Visible = True

        imageBoxLINE.Visible = True

        'ConnectedTitle.Visible = False
        NotConnectedTitle.Visible = True

        BottomElementBg.Visible = True
        bottomBox.Visible = True

        ConnectionImage.Visible = False

        ipImg.Visible = True
        serverImg.Visible = True

        CheckLocationBtn.Visible = True
        ChangeServerBtn.Visible = True

        AllServerPoland.Visible = False
        AllServersPolandbtnConnect.Visible = False
        AllServerUs2.Visible = False
        AllServersUsbtn2Connect.Visible = False

        AllServerLines.Visible = False


        AllServer1stUSServer.Visible = False
        AllServersUsbtnConnect.Visible = False








    End Sub






    Private Sub NavHomeBtn_Click(sender As Object, e As EventArgs) Handles NavHomeBtn.Click
        NavHome()
        Show_MainPage()

    End Sub
    Private Sub NavHomeBtnClick_Click(sender As Object, e As EventArgs) Handles NavHomeBtnClicked.Click
        NavHome()
        Show_MainPage()




    End Sub

    Public Sub NavHome()
        NavHomeBtn.Visible = False
        NavHomeBtnClicked.Visible = True
        NavServersBtn.Visible = True
        NavServersBtnClicked.Visible = False
        NavStreamingBtn.Visible = True
        NavStreamingBtnClicked.Visible = False
        NavSocialBtn.Visible = True
        NavSocialBtnClicked.Visible = False


        Allserverstextimg.Visible = False
        AllServer1stUSServer.Visible = False
        AllServersUsbtnConnect.Visible = False


    End Sub



    Private Sub NavStreamingBtnClicked_Click(sender As Object, e As EventArgs) Handles NavStreamingBtnClicked.Click
        NavStream()
    End Sub

    Private Sub NavStreamingBtn_Click(sender As Object, e As EventArgs) Handles NavStreamingBtn.Click
        NavStream()
    End Sub

    Public Sub NavStream()
        NavHomeBtn.Visible = True
        NavHomeBtnClicked.Visible = False
        NavServersBtn.Visible = True
        NavServersBtnClicked.Visible = False
        NavStreamingBtn.Visible = False
        NavStreamingBtnClicked.Visible = True
        NavSocialBtn.Visible = True
        NavSocialBtnClicked.Visible = False

    End Sub

    Private Sub NavSocialBtnClicked_Click(sender As Object, e As EventArgs) Handles NavSocialBtnClicked.Click
        NavSocial()
    End Sub

    Private Sub NavSocialBtn_Click(sender As Object, e As EventArgs) Handles NavSocialBtn.Click
        NavSocial()
    End Sub

    Public Sub NavSocial()
        NavHomeBtn.Visible = True
        NavHomeBtnClicked.Visible = False
        NavServersBtn.Visible = True
        NavServersBtnClicked.Visible = False
        NavStreamingBtn.Visible = True
        NavStreamingBtnClicked.Visible = False
        NavSocialBtn.Visible = False
        NavSocialBtnClicked.Visible = True
    End Sub

    Private Sub ConnectionImage_Click(sender As Object, e As EventArgs) Handles ConnectionImage.Click
        Dis_connection()

    End Sub
    ' Check if the VPN connection was successful
    Dim isConnected As Boolean = False
    Private Sub NotConnectionImage_Click(sender As Object, e As EventArgs) Handles NotConnectionImage.Click

        VPNConnection()


    End Sub


    Public Sub showSeversPage()
        Allserverstextimg.Visible = True
        AllServer1stUSServer.Visible = True
        AllServer1stUSServer.Enabled = False
        AllServersUsbtnConnect.Visible = True
        AllServerPoland.Visible = True
        AllServersPolandbtnConnect.Visible = True
        AllServerUs2.Visible = True
        AllServersUsbtn2Connect.Visible = True
    End Sub




    Public Sub VPNConnection()
        Try
            ' Show a "Please wait" dialog

            Pleaewait.Visible = True
            NotConnectedTitle.Visible = False
            ConnectedTitle.Visible = False


            If Not IO.Directory.Exists(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\vpnconnector") Then
                IO.Directory.CreateDirectory(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\vpnconnector")
            End If

            IO.File.WriteAllText((System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\vpnconnector" & "\connection.pbk"), "[VPN]" & vbNewLine & "MEDIA=rastapi" & vbNewLine & "Port=VPN2-0" & vbNewLine & "Device=WAN Miniport (IKEv2)" & vbNewLine & "DEVICE=vpn" & vbNewLine & "PhoneNumber=" & "us1.vpnbook.com")

            IO.File.WriteAllText((System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\vpnconnector" & "\connection.bat"), "rasdial ""VPN"" " & "vpnbook" & " " & "3ev7r8m" & " /phonebook:" & """" & System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\vpnconnector" & "\connection.pbk" & """")

            Dim connect As New System.Diagnostics.Process()
            connect.StartInfo.FileName = "cmd.exe"
            connect.StartInfo.Arguments = "/c " & System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\vpnconnector" & "\connection.bat"
            connect.StartInfo.UseShellExecute = False
            connect.StartInfo.RedirectStandardOutput = True
            connect.StartInfo.RedirectStandardError = True
            connect.StartInfo.CreateNoWindow = True

            connect.Start()
            connect.WaitForExit()


            Dim networks As NetworkInformation.NetworkInterface() = NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()

            For Each network As NetworkInformation.NetworkInterface In networks
                If network.Name.Contains("VPN") AndAlso network.OperationalStatus = NetworkInformation.OperationalStatus.Up Then
                    isConnected = True
                    Exit For
                End If
            Next

            ' Display a message depending on the connection status
            If isConnected Then

            Else
                MessageBox.Show("Failed to connect to VPN.")
            End If


        Catch ex As Exception
            ' Display an error message if an exception occurs
            MessageBox.Show("An error occurred: " & ex.Message)

        Finally
            ' Close the "Please wait" dialog

            ' Display a message depending on the connection status
            If isConnected Then

                Pleaewait.Visible = False
                NotConnectedTitle.Visible = False
                ConnectedTitle.Visible = True
                NotConnectionImage.Visible = False
                ConnectionImage.Visible = True

            Else
                MessageBox.Show("Failed to connect to VPN.")

                ConnectionImage.Visible = False
                ConnectedTitle.Visible = False


            End If




        End Try


    End Sub



    Public Sub Dis_connection()

        Try
            ' Show a "Please wait" dialog

            Pleaewait.Visible = True
            NotConnectedTitle.Visible = False
            ConnectedTitle.Visible = False



            IO.File.WriteAllText((System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\vpnconnector" & "\disconnect.bat"), "rasdial /d")

            Dim connect As System.Diagnostics.Process
            connect = New System.Diagnostics.Process()
            connect.StartInfo.FileName = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\vpnconnector" & "\disconnect.bat"
            connect.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            connect.StartInfo.UseShellExecute = False
            connect.StartInfo.CreateNoWindow = True

            connect.Start()
            connect.WaitForExit()

            ' Check if the VPN connection was disconnected
            Dim isDisconnected As Boolean = True
            Dim networks As NetworkInformation.NetworkInterface() = NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()

            For Each network As NetworkInformation.NetworkInterface In networks
                If network.Name.Contains("VPN") AndAlso network.OperationalStatus = NetworkInformation.OperationalStatus.Up Then
                    isDisconnected = False
                    Exit For
                End If
            Next

            ' Display a message depending on the connection status
            If isDisconnected Then
                ConnectedTitle.Visible = False
                NotConnectedTitle.Visible = True
                ConnectionImage.Visible = False
                NotConnectionImage.Visible = True
            Else
                MessageBox.Show("Failed to disconnect from VPN.")
            End If


        Catch ex As Exception
            ' Display an error message if an exception occurs
            MessageBox.Show("An error occurred: " & ex.Message)

        Finally
            ' Close the "Please wait" dialog


            Pleaewait.Visible = False
            NotConnectedTitle.Visible = True
            ConnectedTitle.Visible = False
            NotConnectionImage.Visible = True
            ConnectionImage.Visible = False

        End Try
    End Sub



    Private Sub Form1_Load(sender As Object, e As EventArgs)


        ' Start the timer
        timerIPUpdate.Start()

        '' Update the IP address immediately on form load
        'ShowMyIP()


    End Sub




    Private Sub AllServersPolandbtnConnect_Click(sender As Object, e As EventArgs) Handles AllServersPolandbtnConnect.Click

        NavHome()
        Show_MainPage()
        'lblIPAddress.Visible = True



    End Sub


    Private Sub ChangeServerBtn_Click(sender As Object, e As EventArgs) Handles ChangeServerBtn.Click
        NavServers()
        hide_MainPage()
        showSeversPage()
    End Sub

    Private Sub timerIPUpdate_Tick(sender As Object, e As EventArgs) Handles timerIPUpdate.Tick
        'ShowMyIP()
    End Sub

    Private Sub AllServersUsbtn2Connect_Click(sender As Object, e As EventArgs) Handles AllServersUsbtn2Connect.Click


        NavHome()
        Show_MainPage()

    End Sub
End Class
