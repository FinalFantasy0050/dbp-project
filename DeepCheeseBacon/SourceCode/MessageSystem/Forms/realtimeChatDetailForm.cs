using deepcheesebacon.SourceCode.MessageSystem.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace deepcheesebacon.SourceCode.MessageSystem.Forms
{
    public partial class realtimeChatDetailForm : Form
    {
        private string roomId;
        private ClientWebSocket clientWebSocket;
        private string nickName;

        public realtimeChatDetailForm(string roomId, string nickNmae)
        {
            InitializeComponent();
            this.roomId = roomId;
            Console.WriteLine("생성된 chatRoom ID: " + roomId);

            // WebSocket 연결 시작
            ConnectWebSocketAsync();

            this.nickName = nickNmae;
            AcceptButton = buttonSendMessage;
        }

        private async Task ConnectWebSocketAsync()
        {
            clientWebSocket = new ClientWebSocket();

            string url = "ws://34.64.78.183:9090/ws/chat";

            string testUrl = "ws://localhost:9090/ws/chat";

            // WebSocket 서버 주소
            Uri serverUri = new Uri(testUrl);

            try
            {
                await clientWebSocket.ConnectAsync(serverUri, CancellationToken.None);

                // 연결 성공 시, Enter 메시지를 전송하여 채팅방 입장
                await SendMessageAsync("ENTER", roomId, nickName, "안녕");

                // WebSocket에서 메시지 받기 시작
                ReceiveMessagesAsync();


            }
            catch (Exception ex)
            {
                Console.WriteLine($"WebSocket connection failed: {ex.Message}");
            }
        }

        private async Task ReceiveMessagesAsync()
        {
            try
            {
                while (clientWebSocket.State == WebSocketState.Open)
                {
                    // 메시지 수신
                    WebSocketReceiveResult result;
                    byte[] buffer = new byte[1024];
                    StringBuilder message = new StringBuilder();

                    do
                    {
                        result = await clientWebSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                        // 수신된 메시지가 없으면 루프를 종료
                        if (result.Count == 0)
                        {
                            Console.WriteLine("result count = 0 ");
                            break;
                        }

                        message.Append(Encoding.UTF8.GetString(buffer, 0, result.Count));
                    } while (!result.EndOfMessage);

                    // 수신된 JSON 메시지 trim
                    string trimmedMessage = message.ToString().Trim();

                    // 수신이 끝나면 메시지를 출력
                    Console.WriteLine($"Received message: {trimmedMessage}");

                    // 수신된 JSON 메시지를 파싱
                    if (!string.IsNullOrEmpty(trimmedMessage) && trimmedMessage != "{}")
                    {
                        JObject jsonMessage = JObject.Parse(trimmedMessage);

                        // 수신한 메시지의 형식에 따라 listBoxChatBox에 추가
                        string messageType = jsonMessage["type"]?.ToString();
                        string sender = jsonMessage["sender"]?.ToString();
                        string messageContent = jsonMessage["message"]?.ToString();

                        listBoxChatBox.Items.Add($"{sender}: {messageContent}");
                        Console.WriteLine("메시지 수신 성공 / " + trimmedMessage);
                    }
                    else
                    {
                        Console.WriteLine("Received empty message or {} . Ignoring.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to receive message: {ex.Message}");
            }
        }


        private async Task SendMessageAsync(string type, string roomId, string sender, string message)
        {
            try
            {
                // WebSocket에 전송할 JSON 메시지 생성
                string jsonMessage = $"{{\"type\":\"{type}\",\"roomId\":\"{roomId}\",\"sender\":\"{sender}\",\"message\":\"{message}\"}}";

                // 문자열을 byte 배열로 변환
                byte[] buffer = Encoding.UTF8.GetBytes(jsonMessage);

                // 전송
                await clientWebSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);

                Console.WriteLine("메시지 전송 성공");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send message: {ex.Message}");
            }
        }

        private void buttonSendMessage_Click(object sender, EventArgs e)
        {
            // 텍스트 박스에서 메시지 가져오기
            string message = textBoxInputMessage.Text;

            // 메시지 전송
            SendMessageAsync("TALK", roomId, nickName, message);

            textBoxInputMessage.Clear();
        }

        private void realtimeChatDetailForm_Leave(object sender, EventArgs e)
        {
        }

        private async Task CloseWebSocketAsync()
        {
            try
            {
                if (clientWebSocket != null && clientWebSocket.State == WebSocketState.Open)
                {
                    // 연결 종료 이유와 상태 코드 지정
                    WebSocketCloseStatus closeStatus = WebSocketCloseStatus.NormalClosure;
                    string statusDescription = "Closed by client.";

                    // WebSocket 종료
                    await clientWebSocket.CloseAsync(closeStatus, statusDescription, CancellationToken.None);

                    Console.WriteLine("WebSocket closed.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to close WebSocket: {ex.Message}");
            }
        }

        private void realtimeChatDetailForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseWebSocketAsync();
        }

        private void textBoxInputMessage_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
