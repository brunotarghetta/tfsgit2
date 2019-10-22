import { Injectable } from '@angular/core';
import { Router, NavigationExtras, Route, ActivatedRoute } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class NavigationService {

  constructor(private readonly router: Router,
              private readonly activeRoute: ActivatedRoute) {
  }

  public navigate(fromIdentifier: string, toIdentifier: string, extras?: NavigationExtras) {

    if (!fromIdentifier) { throw new Error('The parameter "fromIdentifier" can not be  null.' ); }
    if (!toIdentifier) { throw new Error('The parameter "toIdentifier" can not be  null.' ); }

    sessionStorage.setItem('previous_path', this.getPathByIdentifier(fromIdentifier));
    this.router.navigate([this.getPathByIdentifier(toIdentifier)], extras);
  }

  public navigateBack(extras?: NavigationExtras) {
    const previousPath = sessionStorage.getItem('previous_path');
    this.router.navigate([previousPath], extras);
  }

  public requestExtras() {
    return this.activeRoute.queryParams;
  }

  public getPathByIdentifier(identifier: string): string {
    const routes = this.router.config.filter( item => item.data && item.path !== null && item.data.identifier );
    const finalPath = this.searchPath(routes, identifier);
    return finalPath ? finalPath : '';
  }

  private searchPath(routes: Route[], identifier: string): string | undefined {
    const finalRoute = routes.find((route) => route.data ? route.data.identifier === identifier : false);
    if (finalRoute) {
      return this.getPath(finalRoute);
    } else {
      for (const currentRoute of routes) {
        if (currentRoute.children) {
          const childRoute = this.searchPath(currentRoute.children, identifier);
          if (childRoute) {
            return `/${this.getPath(currentRoute)}/${childRoute}`;
          }
        }
      }
    }
  }

  private getPath(route: Route): string {
    return route.path ? route.path : '';
  }

  public getDataByPath(routes: Route[] | undefined, url: string): any {
    if (routes && url) {
      const urls = url.split('/').filter(r => r);
      if (urls && urls[0]) {
        const firstUrl = urls[0].split('?')[0];
        const parentRoute = routes.find(route => route.path === firstUrl);
        if (parentRoute) {
          if (urls.length === 1) {
            return parentRoute.data;
          } else {
            const urlRemaining = url.substr(firstUrl.length + 1, url.length);
            return this.getDataByPath(parentRoute.children, urlRemaining);
          }
        }
      }
    }
    return {};
  }
}
