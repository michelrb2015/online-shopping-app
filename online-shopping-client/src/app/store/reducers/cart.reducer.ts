import { createReducer, on } from '@ngrx/store';
import * as CartActions from '../actions/cart.action';
import { Product } from '../../shared/models/product.model';

export interface CartState {
  items: Product[];
}

export const initialState: CartState = {
  items: []
};

const cartReducer = createReducer(
  initialState,
  on(CartActions.addToCart, (state, { product }) => ({
    ...state,
    items: [...state.items, product]
  })),
  on(CartActions.removeFromCart, (state, { productId }) => ({
    ...state,
    items: state.items.filter(item => item.id !== productId)
  }))
);

export function reducer(state: CartState | undefined, action: any) {
  return cartReducer(state, action);
}
