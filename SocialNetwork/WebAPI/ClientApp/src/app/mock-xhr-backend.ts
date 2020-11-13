import { HttpEvent, HttpRequest, HttpResponse, HttpBackend } from '@angular/common/http';
import { Observable, Observer } from 'rxjs';

export class MockXHRBackend implements HttpBackend {
  private users = [
    {
      id:1,
      firstName: 'Ada',
      lastName: 'Lovelace',
      age: 24,
      email: 'ada@gmail.com',
      userName:'ada.love',
      password: 'STRlove'
    },
    {
      id:2,
      firstName: 'Joey',
      lastName: 'Del Marco',
      age: 17,
      email: 'del.marco@gmail.com',
      userName:'jojo',
      password: '12345'
    }, {
      id:3,
      firstName: 'Tim',
      lastName: 'Sidfarh',
      age:18,
      email: 'tim.sidfarh@gmail.com',
      userName:'timmy',
      password: 'passWORD'
    },
  ];

  handle(request: HttpRequest<any>): Observable<HttpEvent<any>> {
    return new Observable((responseObserver: Observer<HttpResponse<any>>) => {
      let responseOptions;
      switch (request.method) {
        case 'GET':
          if (request.urlWithParams.indexOf('users?medium=') >= 0 || request.url === 'users') {
          //   let medium;
          //   if (request.urlWithParams.indexOf('?') >= 0) {
          //     medium = request.urlWithParams.split('=')[1];
          //     if (medium === 'undefined') { medium = ''; }
          //   }
          //   let users;
          //   if (medium) {
          //     users = this.users.filter(i => i.medium === medium);
          //   } else {
          //     users = this.users;
          //   }
          //   responseOptions = {
          //     body: {users: JSON.parse(JSON.stringify(users))},
          //     status: 200
          //   };
          // } else {
            let users;
            const idToFind = parseInt(request.url.split('/')[1], 10);
            users = this.users.filter(i => i.id === idToFind);
            responseOptions = {
              body: JSON.parse(JSON.stringify(users[0])),
              status: 200
            };
          }
          break;
        case 'POST':
          const user = request.body;
          user.id = this._getNewId();
          this.users.push(user);
          responseOptions = {status: 201};
          break;
        case 'DELETE':
          const id = parseInt(request.url.split('/')[1], 10);
          this._deleteUser(id);
          responseOptions = {status: 200};
      }

      const responseObject = new HttpResponse(responseOptions);
      responseObserver.next(responseObject);
      responseObserver.complete();
      return () => {
      };
    });
  }

  _deleteUser(id) {
    const user = this.users.find(i => i.id === id);
    const index = this.users.indexOf(user);
    if (index >= 0) {
      this.users.splice(index, 1);
    }
  }

  _getNewId() {
    if (this.users.length > 0) {
      return Math.max.apply(Math, this.users.map(user => user.id)) + 1;
    } else {
      return 1;
    }
  }
}
