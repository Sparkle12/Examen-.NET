const PROXY_CONFIG = [
  {
    context: [
      "/weatherforecast",
      "/autor"
    ],
    target: "https://localhost:7291",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
