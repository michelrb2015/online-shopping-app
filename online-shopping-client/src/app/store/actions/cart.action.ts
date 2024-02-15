import { createAction, props } from '@ngrx/store';
import { Product } from '../../shared/models/product.model';

export const addToCart = createAction('[Cart] Add To Cart', props<{ product: Product, userId: number }>());
export const removeFromCart = createAction('[Cart] Remove From Cart', props<{ product: Product, userId: number }>());
export const loadCartItems = createAction('[Cart] Load Cart Items', props<{ userId: number }>());
export const loadCartItemsSuccess = createAction('[Cart] Load Cart Items Success', props<{ products: Product[] }>());
export const loadCartItemsFailure = createAction('[Cart] Load Products Items Failure', props<{ error: string }>());
export const placeOrder = createAction('[Cart] Place Order', props<{ userId: number }>());
