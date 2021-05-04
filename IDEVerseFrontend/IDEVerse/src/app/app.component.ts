import { AuthenticationService } from "./services/authentication.service";
import { Component } from "@angular/core";
import { Router } from "@angular/router";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
})
export class AppComponent {
  title = "app";
  currentUser: any;

  constructor(
    private router: Router,
    private authenticationService: AuthenticationService
  ) {
    this.authenticationService.currentUser.subscribe(
      (x) => (this.currentUser = x)
    );
    this.router.events.subscribe(x => { console.log(x); })
  }

  logout() {
    this.authenticationService.logout();
    this.router.navigate(["/login"]);
  }
}
