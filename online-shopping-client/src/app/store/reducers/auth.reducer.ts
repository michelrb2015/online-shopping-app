import { Action, createReducer, on } from '@ngrx/store';
import * as AuthActions from '../actions/auth.action';

export interface AuthState {
  isLoggedIn: boolean;
}

export const initialState: AuthState = {
  isLoggedIn: false
};

const authReducer = createReducer(
  initialState,
  on(AuthActions.loginSuccess, (state) => ({ ...state, isLoggedIn: true })),
  on(AuthActions.loginFailure, (state) => ({ ...state, isLoggedIn: false })),
  on(AuthActions.logout, (state) => ({ ...state, isLoggedIn: false })),
);

export function reducer(state: AuthState | undefined, action: Action) {
  return authReducer(state, action);
}
