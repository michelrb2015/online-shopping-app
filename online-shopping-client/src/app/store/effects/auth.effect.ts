import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, map, switchMap, tap } from 'rxjs/operators';
import { of } from 'rxjs';
import * as AuthActions from '../actions/auth.action';
import { AuthService } from '../../auth/auth.service';

@Injectable()
export class AuthEffects {

  constructor(
    private actions$: Actions,
    private authService: AuthService
  ) {}

  login$ = createEffect(() => this.actions$.pipe(
    ofType(AuthActions.login),
    switchMap(({ username, password }) =>
      this.authService.login(username, password).pipe(
        map(() => {
          return AuthActions.loginSuccess()
        }),
        catchError(error => of(AuthActions.loginFailure({ error })))
      )
    )
  ));

  register$ = createEffect(() => this.actions$.pipe(
    ofType(AuthActions.register),
    switchMap(({ username, email, password }) =>
      this.authService.register(username, email, password).pipe(
        map(() => {
          return AuthActions.registerSuccess()
        }),
        catchError(error => of(AuthActions.registerFailure({ error })))
      )
    )
  ));

}
