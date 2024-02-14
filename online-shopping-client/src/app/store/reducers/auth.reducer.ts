import { Action, createReducer, on } from '@ngrx/store';
import * as AuthActions from '../actions/auth.action';

export interface AuthState {
  isLoggedIn: boolean;
  isRegistered: boolean;
  error: string | null;
}

export const initialState: AuthState = {
  isLoggedIn: false,
  isRegistered: false,
  error: null
};

const authReducer = createReducer(
  initialState,
  on(AuthActions.loginSuccess, (state) => ({ ...state, isLoggedIn: true, error: null })),
  on(AuthActions.loginFailure, (state, { error }) => ({ ...state, isLoggedIn: false, error: error })),
  on(AuthActions.logout, (state) => ({ ...state, isLoggedIn: false, error: null })),
  on(AuthActions.registerSuccess, (state) => ({ ...state, isRegistered: true, error: null})),
  on(AuthActions.registerFailure, (state, { error }) => ({ ...state, isRegistered: false, error: error})),
);

export function reducer(state: AuthState | undefined, action: Action) {
  return authReducer(state, action);
}
