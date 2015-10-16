# WcfHackery

This is just a prototype for hacking on WCF extensibility and making it do things it doesn't do straight out of the box.

Right now, it has behavior that:

Shows you how to host in IIS and still handle basic authentication within your WCF application instead of being tied to IIS
authentication and Active Directory (to do so locally will require installation of a self signed SSL certificate, there is a link to a pretty good tutorial in the web.config walking you through how to do this.)

Type safe method parameters with WebGet/WebInvoke and UriTemplate instead of being restricted to string method arguments.
