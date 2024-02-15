import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, map, switchMap } from 'rxjs/operators';
import { of } from 'rxjs';
import * as CartActions from '../actions/cart.action';
import { CartService } from '../../cart/cart.service';

@Injectable()
export class CartEffects {

  constructor(
    private actions$: Actions,
    private cartService: CartService
  ) {}

  addToCart$ = createEffect(() => this.actions$.pipe(
    ofType(CartActions.addToCart),
    switchMap(({ product, userId }) =>
      this.cartService.addToCart(product, userId).pipe(
        map(() => product),
        catchError(error => of(console.error(error)))
      )
    )
  ), { dispatch: false });

  removeFromCart$ = createEffect(() => this.actions$.pipe(
    ofType(CartActions.removeFromCart),
    switchMap(({ product, userId }) =>
      this.cartService.removeFromCart(product, userId).pipe(
        map(() => product),
        catchError(error => of(console.error(error)))
      )
    )
  ), { dispatch: false });

  loadCartItems$ = createEffect(() => this.actions$.pipe(
    ofType(CartActions.loadCartItems),
    switchMap(({ userId }) =>
      this.cartService.getCartItems(userId).pipe(
        map(products => CartActions.loadCartItemsSuccess({ products })),
        catchError(error => of(CartActions.loadCartItemsFailure({ error })))
      )
    )
  ));

  placeOrder$ = createEffect(() => this.actions$.pipe(
    ofType(CartActions.placeOrder),
    switchMap(({ userId }) =>
      this.cartService.placeOrder(userId).pipe(
        map(() => console.log('Must pay')),
        catchError(error => of(console.error(error)))
      )
    )
  ), { dispatch: false });
}

