import { ActionReducerMap } from '@ngrx/store';
import * as fromCart from './cart.reducer';
import * as fromAuth from './auth.reducer';

export interface AppState {
  cart: fromCart.CartState;
  auth: fromAuth.AuthState;
}

export const reducers: ActionReducerMap<AppState> = {
  cart: fromCart.reducer,
  auth: fromAuth.reducer
};
