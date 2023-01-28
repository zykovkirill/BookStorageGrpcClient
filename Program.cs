using Grpc.Net.Client;
using BookStorageGrpcClient;

// создаем канал для обмена сообщениями с сервером
// параметр - адрес сервера gRPC
using var channel = GrpcChannel.ForAddress("http://localhost:5098");
// создаем клиент
var client = new BookStorage.BookStorageClient(channel);
Console.Write("Введите автора: ");
string? author = Console.ReadLine();
// обмениваемся сообщениями с сервером
var reply = await client.LoadAllBooksAsync(new LoadRequest { Author = author });
Console.WriteLine($"Ответ сервера: {reply.Books}");
Console.ReadKey();