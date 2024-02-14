import { Action, createReducer, on } from '@ngrx/store';
import * as AuthActions from '../actions/auth.action';

export interface AuthState {
  isLoggedIn: boolean;
  userId: number,
  isRegistered: boolean;
  error: string | null;
}

export const initialState: AuthState = {
  isLoggedIn: false,
  userId: 0,
  isRegistered: false,
  error: null
};

const authReducer = createReducer(
  initialState,
  on(AuthActions.loginSuccess, (state, { userId }) => ({ ...state, isLoggedIn: true, userId: userId, error: null })),
  on(AuthActions.loginFailure, (state, { error }) => ({ ...state, isLoggedIn: false, userId: 0, error: error })),
  on(AuthActions.logout, (state) => ({ ...state, isLoggedIn: false, userId: 0, error: null })),
  on(AuthActions.registerClean, (state) => ({ ...state, isRegistered: false, error: null })),
  on(AuthActions.registerSuccess, (state) => ({ ...state, isRegistered: true, error: null})),
  on(AuthActions.registerFailure, (state, { error }) => ({ ...state, isRegistered: false, error: error})),
);

export function reducer(state: AuthState | undefined, action: Action) {
  return authReducer(state, action);
}
