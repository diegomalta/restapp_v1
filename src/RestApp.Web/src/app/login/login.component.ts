import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/shared/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  public creds = {
    username: '',
    password: ''
  };
  errorMessage: string;

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit(): void {
    if (this.authService.isAuthenticated()) {
      this.router.navigate(['/home']);
    }
  }

  signIn = (): void => {
    this.authService.login(this.creds)
      .subscribe(success => {
        if (success) {
          this.router.navigate(['/home']);
        }
      }, err => { this.errorMessage = 'error'; });
  }

}
