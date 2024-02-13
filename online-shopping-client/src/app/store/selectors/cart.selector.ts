import { createSelector } from '@ngrx/store';
import { AppState } from '../reducers';

const selectCart = (state: AppState) => state.cart;

export const selectCartItems = createSelector(
  selectCart,
  (cart) => cart.items
);

export const selectCartTotal = createSelector(
  selectCartItems,
  (items) => {
    return items.reduce((total, item) => total + item.price, 0);
  }
);
