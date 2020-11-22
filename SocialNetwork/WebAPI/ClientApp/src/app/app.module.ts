import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { ProfileComponent } from './profile/profile.component';
import { ChatListComponent } from './chat/chat-list/chat-list.component';
import { FriendsListComponent } from './friend/friends-list/friends-list.component';
import { FriendSearchComponent } from './friend/friend-search/friend-search.component';
import { EditProfileComponent } from './profile/edit-profile/edit-profile.component';
import { RegistrationComponent } from './user/auth/registration/registration.component';
import { LoginComponent } from './user/auth/login/login.component';
import { HomeComponent } from './home/home.component';
import { ForbiddenComponent } from './user/auth/forbidden/forbidden.component';
import { UserService } from './user/user.service';
import { AuthInterceptor } from './user/auth/auth.interceptor';
import { AuthGuard } from './user/auth/auth.guard';
import { ToastrModule, ToastrService } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AdminPanelComponent } from './admin-panel/admin-panel.component';
import { ChatComponent } from './chat/chat/chat.component';
import { FriendProfileComponent } from './friend/friend-profile/friend-profile.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    ProfileComponent,
    ChatListComponent,
    FriendsListComponent,
    FriendSearchComponent,
    EditProfileComponent,
    RegistrationComponent,
    LoginComponent,
    HomeComponent,
    ForbiddenComponent,
    AdminPanelComponent,
    ChatComponent,
    FriendProfileComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      progressBar: true
    }),
    RouterModule.forRoot([
      { path: '', component: ProfileComponent, pathMatch: 'full', canActivate:[AuthGuard] },
      {path: 'profile', component: EditProfileComponent, canActivate:[AuthGuard]},
      { path: 'chats', component:  ChatListComponent, canActivate:[AuthGuard]},
      { path: 'friends', component: FriendsListComponent, canActivate:[AuthGuard]},
      { path: 'search', component: FriendSearchComponent, canActivate:[AuthGuard]},
      { path: 'friend/profile', component: FriendProfileComponent, canActivate:[AuthGuard]},
      { path: 'registration', component: RegistrationComponent },
      { path: 'login', component: LoginComponent},
      {path:'forbidden',component:ForbiddenComponent},
      {path:'chat',component:ChatComponent},
      {path:'admin',component:AdminPanelComponent, canActivate:[AuthGuard],data :{permittedRoles:['Admin']}}
    ])
  ],
  providers: [UserService, {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  },
  ToastrService
],

  bootstrap: [AppComponent]
})
export class AppModule { }
