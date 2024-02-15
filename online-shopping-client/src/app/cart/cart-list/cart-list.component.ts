import { Component, OnDestroy } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { AppState } from '../../store/reducers';
import { Product } from '../../shared/models/product.model';
import { Observable, Subscription } from 'rxjs';
import { selectCartItems, selectCartTotal } from '../../store/selectors';
import { userId } from '../../store/selectors';
import * as CartActions from '../../store/actions/cart.action';
import { CommonModule } from '@angular/common';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-cart-list',
  standalone: true,
  imports: [MatButtonModule, MatCardModule, MatDividerModule,MatIconModule, CommonModule],
  templateUrl: './cart-list.component.html',
  styleUrl: './cart-list.component.scss'
})
export class CartListComponent implements OnDestroy {
  cartListItem$: Observable<Product[]> | undefined;
  cartTotalItem$: Observable<number> | undefined;
  userId: number = 0;
  userIdSubscription$: Subscription | undefined;

  constructor(
    private store: Store<AppState>,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.cartListItem$ = this.store.select(selectCartItems);
    this.cartTotalItem$ = this.store.select(selectCartTotal);

    this.userIdSubscription$ = this.store.select(userId).subscribe(userId => {
      this.store.dispatch(CartActions.loadCartItems({userId}))
      this.userId = userId;
    });
  }

  removeFromCart(product: Product) {
    this.store.dispatch(CartActions.removeFromCart({product: product, userId: this.userId}))
  }

  goToProducts() {
    this.router.navigate(['products']);
  }

  ngOnDestroy(): void {
    this.userIdSubscription$?.unsubscribe()
  }
}
