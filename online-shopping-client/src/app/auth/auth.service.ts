import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, map, of, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {

  baseAuthUrl = 'http://localhost:5212/api/user'
  constructor(private http$: HttpClient) { }

  login(username: string, password: string): Observable<any> {
    return this.http$.post(`${this.baseAuthUrl}/login`, { username, password}).pipe(
      map((response: any)=> response.id),
      catchError(err=>{
        return throwError(()=> new Error(err.error.message));
      })
    );
  }

  logout(): Observable<boolean> {
    return of(true);
  }

  register(username: string, email: string, password: string): Observable<boolean> {
    return this.http$.post(`${this.baseAuthUrl}/register`, { username, email, password}).pipe(
      map((response: any)=> {
        console.log(response)
        return true;
      }),
      catchError(err=>{
        return throwError(()=> new Error(err.error.message));
      })
    );
  }
}
