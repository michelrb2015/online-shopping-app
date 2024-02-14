import { Component, Inject, Input, inject } from "@angular/core";
import { MatButtonModule } from "@angular/material/button";
import {
  MAT_SNACK_BAR_DATA,
  MatSnackBarAction,
  MatSnackBarActions,
  MatSnackBarLabel,
  MatSnackBarRef,
} from '@angular/material/snack-bar';
@Component({
  selector: 'app-snackbar-error',
  templateUrl: './snackbar-error.component.html',
  styles: [
    `
    :host {
      display: flex;
    }
    .error {
      color: hotpink;
    }
  `,
  ],
  standalone: true,
  imports: [MatButtonModule, MatSnackBarLabel, MatSnackBarActions, MatSnackBarAction],
})
export class SnackbarErrorComponent {

  constructor(@Inject(MAT_SNACK_BAR_DATA) public data: string) {}

}
