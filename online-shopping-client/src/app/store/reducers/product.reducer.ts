import { Action, createReducer, on } from '@ngrx/store';
import * as ProductActions from '../actions/product.action';
import { Product } from '../../shared/models/product.model';

export interface ProductState {
  products: Product[];
  loading: boolean;
  error: any;
}

export const initialState: ProductState = {
  products: [],
  loading: false,
  error: null
};

const productsReducer = createReducer(
  initialState,
  on(ProductActions.loadProducts, state => ({ ...state, loading: true })),
  on(ProductActions.loadProductsSuccess, (state, { products }) => ({ ...state, products, loading: false, error: null })),
  on(ProductActions.loadProductsFailure, (state, { error }) => ({ ...state, loading: false, error }))
);

export function reducer(state: ProductState | undefined, action: Action) {
  return productsReducer(state, action);
}
