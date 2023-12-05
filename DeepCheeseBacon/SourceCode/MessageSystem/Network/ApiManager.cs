using deepcheesebacon.SourceCode.MessageSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Net.WebSockets;

namespace deepcheesebacon
{
    internal class ApiManager
    {

        private static ClientWebSocket clientWebSocket;

        public static async Task<ChatRoom> CreateChatRoomAsync(string roomName)
        {
            DBManager db = DBManager.GetInstance();

            string url = "http://34.64.78.183:9090/chat";

            string testUrl = "http://localhost:9090/chat";

            using (HttpClient client = new HttpClient())
            {
                // 생성할 채팅방 객체 생성
                ChatRoom chatRoom =  new ChatRoom{ Name = roomName };

                // ChatRoom 객체를 JSON 문자열로 변환
                string jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(roomName);

                Console.WriteLine("api 실행");
                // 서버의 ChatController에 POST 요청을 보냄
                HttpResponseMessage response = await client.PostAsync(url,
                    new StringContent(jsonContent, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    // 응답으로 받은 데이터를 문자열로 변환
                    string responseData = await response.Content.ReadAsStringAsync();

                    // 문자열을 ChatRoom 객체로 변환 (이 부분은 서버에서 어떤 형식으로 응답하는지에 따라 수정 필요)
                    // 예제로 ChatRoom 클래스가 있다고 가정
                    ChatRoom createdChatRoom = Newtonsoft.Json.JsonConvert.DeserializeObject<ChatRoom>(responseData);

                    // 생성된 채팅방 정보를 사용하여 UI를 구성하거나 필요한 작업 수행
                    Console.WriteLine($"Room created with ID: {createdChatRoom.RoomId} Name: {createdChatRoom.Name}");
                    return chatRoom;

                }
                else
                {
                    Console.WriteLine($"Failed to create chat room. Status code: {response.StatusCode}");
                    return null;
                }
            }
        }

        public static async Task<List<ChatRoom>> GetChatRoomsAsync()
        {

            string url = "http://34.64.78.183:9090/chat";

            string testUrl = "http://localhost:9090/chat";

            using (HttpClient client = new HttpClient())
            {
                Console.WriteLine("GetChatRoomsAsync API GET 실행");

                // 서버의 ChatController에 GET 요청을 보냄
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    // 응답으로 받은 데이터를 문자열로 변환
                    string responseData = await response.Content.ReadAsStringAsync();

                    // 서버에서 빈 배열을 반환할 경우 예외 처리
                    if (responseData == "[]")
                    {
                        Console.WriteLine("No chat rooms found.");
                        return new List<ChatRoom>(); // 빈 리스트 반환 또는 null 반환
                    }

                    // 문자열을 List<ChatRoom>으로 변환
                    List<ChatRoom> chatRooms = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ChatRoom>>(responseData);

                    foreach (var chatRoom in chatRooms)
                    {
                        Console.WriteLine($"Chat room retrieved with ID: {chatRoom.RoomId} name: {chatRoom.Name}");
                    }

                    Console.WriteLine("chatRooms length: " + chatRooms.Count);

                    return chatRooms;
                }
                else
                {
                    Console.WriteLine($"Failed to retrieve chat rooms. Status code: {response}");
                    return null;
                }
            }
        }

        internal static async Task<List<ChatRoom>> GetChatSecretRoomsAsync()
        {
            string url = "http://34.64.78.183:9090/chat/secret";

            string testUrl = "http://localhost:9090/chat/secret";

            using (HttpClient client = new HttpClient())
            {
                Console.WriteLine("GetChatSecretRoomsAsync API GET 실행");

                // 서버의 ChatController에 GET 요청을 보냄
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    // 응답으로 받은 데이터를 문자열로 변환
                    string responseData = await response.Content.ReadAsStringAsync();

                    // 서버에서 빈 배열을 반환할 경우 예외 처리
                    if (responseData == "[]")
                    {
                        Console.WriteLine("No chat rooms found.");
                        return new List<ChatRoom>(); // 빈 리스트 반환 또는 null 반환
                    }

                    // 문자열을 List<ChatRoom>으로 변환
                    List<ChatRoom> chatRooms = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ChatRoom>>(responseData);

                    foreach (var chatRoom in chatRooms)
                    {
                        Console.WriteLine($"Chat room retrieved with ID: {chatRoom.RoomId} name: {chatRoom.Name}");
                    }

                    Console.WriteLine("chatRooms length: " + chatRooms.Count);

                    return chatRooms;
                }
                else
                {
                    Console.WriteLine($"Failed to retrieve secret chat rooms. Status code: {response}");
                    return null;
                }
            }
        }

        internal static async Task<ChatRoom> CreateChatSecretRoomAsync(string roomName)
        {
            DBManager db = DBManager.GetInstance();

            string url = "http://34.64.78.183:9090/chat/secret";

            string testUrl = "http://localhost:9090/chat/secret";

            using (HttpClient client = new HttpClient())
            {
                // 생성할 채팅방 객체 생성
                ChatRoom chatRoom = new ChatRoom { Name = roomName };

                // ChatRoom 객체를 JSON 문자열로 변환
                string jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(roomName);

                Console.WriteLine("api 실행");
                // 서버의 ChatController에 POST 요청을 보냄
                HttpResponseMessage response = await client.PostAsync(url,
                    new StringContent(jsonContent, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    // 응답으로 받은 데이터를 문자열로 변환
                    string responseData = await response.Content.ReadAsStringAsync();

                    // 문자열을 ChatRoom 객체로 변환 (이 부분은 서버에서 어떤 형식으로 응답하는지에 따라 수정 필요)
                    // 예제로 ChatRoom 클래스가 있다고 가정
                    ChatRoom createdChatRoom = Newtonsoft.Json.JsonConvert.DeserializeObject<ChatRoom>(responseData);

                    // 생성된 채팅방 정보를 사용하여 UI를 구성하거나 필요한 작업 수행
                    Console.WriteLine($"Room created with ID: {createdChatRoom.RoomId} Name: {createdChatRoom.Name}");
                    return chatRoom;

                }
                else
                {
                    Console.WriteLine($"Failed to create secret chat room. Status code: {response.StatusCode}");
                    return null;
                }
            }
        }
    }
}
