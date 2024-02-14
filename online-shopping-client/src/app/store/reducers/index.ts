import { ActionReducerMap } from '@ngrx/store';
import * as fromCart from './cart.reducer';
import * as fromAuth from './auth.reducer';
import * as fromProducts from './product.reducer';

export interface AppState {
  cart: fromCart.CartState;
  auth: fromAuth.AuthState;
  products: fromProducts.ProductState;
}

export const reducers: ActionReducerMap<AppState> = {
  cart: fromCart.reducer,
  auth: fromAuth.reducer,
  products: fromProducts.reducer
};
