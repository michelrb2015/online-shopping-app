import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import * as ProductActions from '../actions/product.action';
import { catchError, map, switchMap } from 'rxjs/operators';
import { of } from 'rxjs';
import { ProductService } from '../../products/products.service';

@Injectable()
export class ProductEffects {

  constructor(private actions$: Actions, private productService: ProductService) {}

  loadProducts$ = createEffect(() => this.actions$.pipe(
    ofType(ProductActions.loadProducts),
    switchMap(() =>
      this.productService.getProducts().pipe(
        map(products => ProductActions.loadProductsSuccess({ products })),
        catchError(error => of(ProductActions.loadProductsFailure({ error })))
      )
    )
  ));

}
