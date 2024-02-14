import { Injectable } from '@angular/core';
import { Observable, of, throwError } from 'rxjs';
import { delay } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor() { }

  login(username: string, password: string): Observable<number> {
    if (username === 'admin' && password === 'admin') {
      return of(1);
    } else {
      return throwError(()=> new Error('Invalid username or password'));
    }
  }

  logout(): Observable<boolean> {
    return of(true);
  }

  register(username: string, email: string, password: string): Observable<boolean> {
    if (username !== 'admin' && email !== 'admin') {
      return of(true);
    } else {
      return throwError(()=> new Error('User already exists'));
    }
  }
}
