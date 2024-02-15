import { createSelector } from '@ngrx/store';
import { AppState } from '../reducers';

const selectCart = (state: AppState) => state.cart;

export const selectCartItems = createSelector(
  selectCart,
  (cart) => cart.products
);

export const selectCartTotal = createSelector(
  selectCartItems,
  (products) => {
    return products.reduce((total, item) => total + item.price * (item.quantity || 1), 0);
  }
);

export const selectCartQuantity = createSelector(
  selectCartItems,
  (products) => {
    return products.reduce((total, item) => total + (item.quantity || 0), 0);
  }
);

export const selectCartLoading = createSelector(
  selectCart,
  state => state.loading
);

export const selectCartError = createSelector(
  selectCart,
  state => state.error
);
