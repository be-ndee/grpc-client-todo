using System.Threading.Tasks;
using Grpc.Net.Client;
using grpc_client_todo;

// The port number must match the port of the gRPC server.
using var channel = GrpcChannel.ForAddress("http://localhost:5181");
var client = new TodoItems.TodoItemsClient(channel);

var allReply = await client.GetListAsync(new ListRequest { OnlyOpen = false });
Console.WriteLine("Items: " + allReply.Items);

var onlyOpenReply = await client.GetListAsync(new ListRequest { OnlyOpen = true });
Console.WriteLine("Items: " + onlyOpenReply.Items);

Console.ReadKey();
