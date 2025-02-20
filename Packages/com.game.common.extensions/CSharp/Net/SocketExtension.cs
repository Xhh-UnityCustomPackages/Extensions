using System.Net.Sockets;

namespace Game
{
    public static class SocketExtension
    {
        public static bool IsConnected(this Socket socket)
        {
            var part1 = socket.Poll(1000, SelectMode.SelectRead);
            var part2 = (socket.Available == 0);
            var result = part1 & part2;
            return result;
        }
    }
}
