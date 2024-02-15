import { Component, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { MatBadgeModule } from '@angular/material/badge';
import { AppState } from '../../store/reducers';
import { Store } from '@ngrx/store';
import { selectProducts } from '../../store/selectors/product.selector';
import { Product } from '../../shared/models/product.model';
import { Observable, Subscription } from 'rxjs';
import * as ProductActions from '../../store/actions/product.action';
import * as CartActions from '../../store/actions/cart.action';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { selectCartQuantity, userId } from '../../store/selectors';

@Component({
  selector: 'app-product-list',
  standalone: true,
  imports: [MatButtonModule, MatCardModule, MatIconModule, MatBadgeModule, CommonModule],
  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.scss'
})
export class ProductListComponent implements OnInit {
  productList$: Observable<Product[]> | undefined;
  cartQuantity$: Observable<number> | undefined;
  userIdSubscription$: Subscription | undefined;
  userId: number = 0;

  constructor(
    private store: Store<AppState>,
    private router: Router
  ) {}
  ngOnInit(): void {
    this.productList$ = this.store.select(selectProducts);
    this.cartQuantity$ = this.store.select(selectCartQuantity);

    this.userIdSubscription$ = this.store.select(userId).subscribe(userId => {
      this.userId = userId;
    })

    this.store.dispatch(ProductActions.loadProducts())
    this.refreshCart()
  }

  addToCart(product: Product) {
    this.store.dispatch(CartActions.addToCart({ product, userId: this.userId }))
    this.refreshCart()
  }

  refreshCart() {
    this.store.dispatch(CartActions.loadCartItems({userId: this.userId}))
  }

  goToCart() {
    this.router.navigate(['cart']);
  }
}
