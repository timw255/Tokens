# Tokens

This is an example of how to support tokens in Sitefinity content.

[Watch a demonstration on YouTube (0:37)](https://youtu.be/FhAAaeQznUM)

#### Installation

1. Copy the "Tokens" folder to the root of your Sitefinity project
2. Subscribe TokenReplacer to IPagePreRenderCompleteEvent using the example in 'Global.ascx.txt'
3. Build

#### After installation

Navigate to _Administration -> Settings -> Advanced -> Tokens_ to define your tokens.

By default, the replacer will look for tokens in the form of {{sometext}}.


#### Using tokens in Sitefinity content

Place tokens inside of your content, publish, then view the content on the front-end of your Sitefinity instance. The token should have been replaced with the defined value.