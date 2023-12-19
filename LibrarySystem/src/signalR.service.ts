
import { Injectable, EventEmitter } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  hubConnection!: HubConnection;
  responseReceived = new EventEmitter<any>();
  requestReceived = new EventEmitter<any>();
  connectionId: string = "";
  responseResult:boolean = false;
  bookid:string="0";
  constructor() {
    this.startConnection();
  }

  startConnection(): void {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl('https://localhost:7255/chatHub')
      .build();

    this.hubConnection
      .start()
      .then(() => {
        console.log('SignalR connection started.');
        this.getConnectionId();
        this.setupEventHandlers();
      })
      .catch((error) => {
        console.error('Error starting SignalR connection:', error);
      });
  }

  private getConnectionId(): void {
    this.hubConnection
      .invoke('GetConnectionId')
      .then((connectionId: string) => {
        this.connectionId = connectionId;
        console.log('Connection ID:', connectionId);
      })
      .catch((err) => console.error('Error getting connection ID:', err));
  }

  private setupEventHandlers(): void {
    this.hubConnection.on('RequestReceived', (userId: string, bookId: string) => {

      this.sendResponse(userId, bookId); 
    });
    
  }


  sendRequest(bookId: string): Promise<boolean> {
    this.bookid=bookId
    return new Promise<boolean>(async (resolve) => {
      const trySendRequest = async () => {
        if (this.hubConnection) {
          if (this.hubConnection.state === 'Disconnected') {
            await this.startConnection();
          } else if (this.hubConnection.state === 'Connected') {
            const hasMatchingBookId = await this.invokeRequest(bookId);
            this.responseResult = hasMatchingBookId;
            resolve(this.responseResult);
          } else if (this.hubConnection.state === 'Connecting') {
            setTimeout(trySendRequest, 100);
          }
        } else {
          console.error('SignalR connection is undefined.');
          resolve(false);
        }
      };
  
      trySendRequest();
    });
  }
  
private dewid(){
  console.log("tempsadasdasd")
}

private async _startConnection(): Promise<void> {
  try {
    await this.hubConnection.start();
    console.log('SignalR connection started.');
    this.getConnectionId();
    this.setupEventHandlers();
  } catch (error) {
    console.error('Error starting SignalR connection:', error);
  }
}

private invokeRequest(bookId: string): Promise<boolean> {
  return new Promise<boolean>((resolve) => {
    let hasMatchingBookId = false;

    const responseHandler = (bookIds: string) => {
      console.log(bookId)
      console.log(bookIds)
      if (bookId == bookIds) {
        hasMatchingBookId = true;
        this.responseResult = true;
      }
      console.log("Here" + this.responseResult);
      // Unsubscribe the event handler after the first response is received
    //  this.hubConnection.off('ResponseReceived', responseHandler);
      // Resolve the promise after processing the response
      resolve(hasMatchingBookId);
    };

    this.hubConnection.on('ResponseReceived', responseHandler);

    this.hubConnection
      .invoke('SendRequest', this.connectionId, bookId)
      .catch((error) => {
        console.error('Error sending request:', error);
        // If there's an error, resolve with false
        resolve(false);
      });
  });
}







  sendResponse(userId: string, bookId: string): void {
    if (this.hubConnection && this.hubConnection.state === 'Connected') {
      this.hubConnection.invoke('SendResponse', userId, this.bookid)
        .catch((error) => {
          console.error('Error sending response:', error);
        });
    } else {
      console.error('SignalR connection is not in the Connected state.');
    }
  }
}
