import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IdentityComponent } from './identity.component';
import { ProfileComponent } from './components/profile/profile.component';
import { MaterialModule } from 'src/app/core/material/material.module';
import { SharedModule } from 'src/app/core/shared/shared.module';
import { IdentityRoutingModule } from './identity-routing.module';



@NgModule({
  declarations: [
    IdentityComponent,
    ProfileComponent
  ],
  imports: [
    CommonModule,
    IdentityRoutingModule,
    MaterialModule,
    SharedModule
  ]
})
export class IdentityModule { }