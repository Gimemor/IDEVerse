import { Observable } from "rxjs";
import { AuthenticationService } from "src/app/services/authentication.service";
import { Component, Output } from "@angular/core";
import { RightsMnemos } from "src/app/entities/user-right";
import { Router } from "@angular/router";

@Component({
  selector: "app-nav-menu",
  templateUrl: "./nav-menu.component.html",
  styleUrls: ["./nav-menu.component.css"],
})
export class NavMenuComponent {
  isExpanded = false;
  userName: string;
  rights = RightsMnemos;
  constructor(
    public router: Router,
    public authService: AuthenticationService
  ) {
    this.userName = authService.currentUserValue.firstName;
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  onLogout() {
    this.authService.logout();
    this.router.navigate(["/login"]);
  }
}
