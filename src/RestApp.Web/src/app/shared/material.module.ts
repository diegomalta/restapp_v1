import { NgModule } from '@angular/core';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';

@NgModule({
  exports: [
    MatToolbarModule,
    MatCardModule,
    MatInputModule,
    MatButtonModule
  ],
  imports: [
    MatToolbarModule,
    MatCardModule,
    MatInputModule,
    MatButtonModule
  ]
})
export class MaterialModule { }
