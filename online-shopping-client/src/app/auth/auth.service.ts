import { Injectable } from '@angular/core';
import { Observable, of, throwError } from 'rxjs';
import { delay } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor() { }

  login(username: string, password: string): Observable<boolean> {
    if (username === 'admin' && password === 'admin') {
      return of(true);
    } else {
      return throwError(()=> new Error('Invalid username or password'));
    }
  }

  logout(): Observable<boolean> {
    return of(true).pipe(delay(1000));
  }
}
