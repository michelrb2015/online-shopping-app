import { createReducer, on } from '@ngrx/store';
import * as CartActions from '../actions/cart.action';
import { Product } from '../../shared/models/product.model';

export interface CartState {
  products: Product[];
  loading: boolean;
  error: any;
}

export const initialState: CartState = {
  products: [],
  loading: false,
  error: null
};

const cartReducer = createReducer(
  initialState,
  on(CartActions.addToCart, (state, { product }) => ({
    ...state,
    products: [...state.products, product]
  })),
  on(CartActions.removeFromCart, (state, { product }) => ({
    ...state,
    products: state.products.filter(item => item.id !== product.id)
  })),
  on(CartActions.loadCartItems, state => ({ ...state, loading: true })),
  on(CartActions.loadCartItemsSuccess, (state, { products }) => ({ ...state, products, loading: false, error: null })),
  on(CartActions.loadCartItemsFailure, (state, { error }) => ({ ...state, loading: false, error }))
);

export function reducer(state: CartState | undefined, action: any) {
  return cartReducer(state, action);
}
