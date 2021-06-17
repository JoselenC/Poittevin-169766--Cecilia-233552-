import {ErrorHandler, Injectable, NgZone} from '@angular/core';

import {MatSnackBar} from '@angular/material/snack-bar';


@Injectable(
  {providedIn: 'root'}
)
export class CustomErrorHandler implements ErrorHandler {
  constructor(
    public snackBar: MatSnackBar,
    private readonly zone: NgZone
  ) {
  }

  handleError(error: any): void {
    if (error.status !== undefined && error.status >= 400) {
      if (error.error.errors !== undefined) {
        for (let key in error.error.errors) {
          this.zone.run(() => {
            this.snackBar.open(key + ' ' + error.error.errors[key], 'close');
          });
        }
      } else {
        this.zone.run(() => {
          this.snackBar.open(error.error.content, 'close');
        });
      }
    } else {
      this.zone.run(() => {
        if (error.error !== undefined && error.error.text !== undefined) {
          this.snackBar.open(error.error.text, 'close');
        } else {
          this.snackBar.open(error.text, 'close');
        }
      });
    }
  }
}

