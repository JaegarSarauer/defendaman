CC = g++ -Wall -pedantic -W -ggdb

make:
all: TCPClient UDPClient EchoServer


UDPClient:	game.o Client.o
	$(CC) Client.o -g game.o -o Game

TCPClient:	main.o Client.o
	$(CC) Client.o -g main.o -o Lobby

EchoServer:
	$(CC) -o EchoServer udp_echo_svr.c

clean:
	rm -f *.o core.* Game Lobby EchoServer

Client.o: Client.cpp Client.h
	$(CC) -c -g Client.cpp

game.o:	game.cpp
	$(CC) -c -g game.cpp

main.o: main.cpp
	$(CC) -c -g main.cpp
