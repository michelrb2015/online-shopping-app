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
    switchMap(({ product }) =>
      this.cartService.addToCart(product).pipe(
        map(() => ({ type: 'NO_ACTION' })),
        catchError(error => of(console.error(error)))
      )
    )
  ), { dispatch: false });

  removeFromCart$ = createEffect(() => this.actions$.pipe(
    ofType(CartActions.removeFromCart),
    switchMap(({ productId }) =>
      this.cartService.removeFromCart(productId).pipe(
        map(() => ({ type: 'NO_ACTION' })),
        catchError(error => of(console.error(error)))
      )
    )
  ), { dispatch: false });
}

